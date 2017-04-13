#include <string>
#include<iostream>
#include<iomanip>//for setw()
#include"windows.h"

using namespace std;

#import "C:\Program Files\Common Files\System\ado\msado15.dll" no_namespace rename("EOF","EndOfFile")
class STU
{
public:
	char snum[10];
	char sname[10];
	char ssex[2];
	long sage;
	char smajor[20];
public:
	STU(){}
	~STU(){}
};

int main()
{
	STU student;

	::CoInitialize(NULL);//初始化OLE/COM库环境，为访问ADO接口做准备

	//_RecordsetPtr智能指针，可以用来打开库内数据表，并可以对表内的记录、字段等进行各种操作
	_RecordsetPtr m_pRecordset("ADODB.Recordset");//定义记录集对象

	//_ConnectionPtr智能指针，通常用于打开、关闭一个库连接或用它的Execute方法来执行一个不返回结果的命令语句
	_ConnectionPtr m_pConnection("ADODB.Connection");//定义数据库连接对象

	_bstr_t bstrSQL("select * from stu_info");//查询语句

	char* query_cmd = " delete from stu_info where sname = '本拉登'";

	try
	{
		m_pConnection.CreateInstance("ADODB.Connection");//创建Connection对象

		//设置连接字符串，必须是BSTR型或者_bstr_t类型,若数据库在网络上则Server为形如(192.168.1.5,3340) 
		_bstr_t strConnect = "Provider=SQLOLEDB;Server=DESKTOP-J4JFLTU\\SQLEXPRESS; Database=MyFirstDataBase; uid=sa; pwd=529147";
		m_pConnection->Open(strConnect, "", "", adModeUnknown);//NULL、adConnectUnspecified、//建立与服务器连接

		if(m_pConnection == NULL)
		{
			cerr << "Link data ERROR!\n";
		}

		m_pRecordset.CreateInstance(__uuidof(Recordset));//创建记录集对象

		//取得表中的记录
		m_pRecordset->Open(bstrSQL, m_pConnection.GetInterfacePtr(), adOpenDynamic, adLockOptimistic, adCmdText);

		_variant_t vsnum, vsname, vsage, vssex, vsmajor;//对应库中的snum,sname,sage,ssex,smajor

		cout << "学号          姓名          年龄   性别     专业";
		cout << "\n---------------------------------------------------\n";

		while(!m_pRecordset->EndOfFile)
		{
			vsnum = m_pRecordset->GetCollect(_variant_t((long)0));//这儿给字段编号和字段名都可以
			vsname = m_pRecordset->GetCollect("sname");
			vsage = m_pRecordset->GetCollect("sage");
			vssex = m_pRecordset->GetCollect("ssex");
			vsmajor = m_pRecordset->GetCollect("smajor");

			if(vsnum.vt != VT_NULL && vsname.vt != VT_NULL&& vsage.vt != VT_NULL &&
				vssex.vt != VT_NULL&& vsmajor.vt != VT_NULL)
			{
				cout.setf(ios::left);//设置n个字符是以左边对齐方式
				cout << setw(14) << (char*)(_bstr_t)vsnum;//setw(n)设置字段宽度为n位
				cout << setw(14) << (char*)(_bstr_t)vsname;
				cout << setw(8) << vsage.lVal;
				cout << setw(8) << (char*)(_bstr_t)vssex;
				cout << setw(20) << (char*)(_bstr_t)vsmajor;
				cout.unsetf(ios::left);
				cout << endl;
// 				cout.setf(ios::right);
// 				cout <<(char*)(_bstr_t)vsnum<<"  ";
// 				cout << (char*)(_bstr_t)vsname << "  ";
// 				cout << vsage.lVal << "  ";
// 				cout << (char*)(_bstr_t)vssex << "  ";
// 				cout << (char*)(_bstr_t)vsmajor << "  ";
// 				cout.unsetf(ios::right);
// 				cout << endl;

			}

			m_pRecordset->MoveNext();//移动下一条记录
		}

		cout << "\n---------------------------------------------------\n";
		cout << "\n添加一条数据！！！\n";
		cout << "\n请输入你要添加的学生信息\n";
		cout << "学号：";
		cin >> student.snum;
		cout << "\n姓名：";
		cin >> student.sname;
		cout << "\n年龄：";
		cin >> student.sage;
		cout << "\n性别：";
		cin >> student.ssex;
		cout << "\n专业：";
		cin >> student.smajor;

		m_pRecordset->MoveFirst();//移动到第一条记录
		m_pRecordset->AddNew();//添加新记录
		m_pRecordset->PutCollect("snum", _variant_t(student.snum));
		m_pRecordset->PutCollect("sname", _variant_t(student.sname));
		m_pRecordset->PutCollect("sage", _variant_t(student.sage));
		m_pRecordset->PutCollect("ssex", _variant_t(student.ssex));
		m_pRecordset->PutCollect("smajor", _variant_t(student.smajor));
		m_pRecordset->Update();

		cout << "\n删除一条数据！！！\n";
		m_pConnection->Execute(query_cmd, NULL, 1);//用Execute执行sql语句来删除

		m_pRecordset->Close();//关闭记录集
	}
	catch(_com_error e)//捕捉异常
	{
		cerr << "\nERROR:" << (char*)e.Description();//抛出异常
	}

	if(m_pConnection->State)
	{
		m_pConnection->Close();
	}

	::CoUninitialize();

	return 0;
}