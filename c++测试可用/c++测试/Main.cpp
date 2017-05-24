#include <string>
#include<iomanip>
#include<iostream>
#include<iomanip>//for setw()
#include"windows.h"
#include <comdef.h>
#include <atlstr.h>

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

	//_bstr_t bstrSQL("select * from stu_info");//查询语句
	_bstr_t bstrSQL("select G0_in,G1_in,G2_in from B1 where t_ri=0.01 and a_t=0");//查询语句


	try
	{
		m_pConnection.CreateInstance("ADODB.Connection");//创建Connection对象

		//设置连接字符串，必须是BSTR型或者_bstr_t类型,若数据库在网络上则Server为形如(192.168.1.5,3340) 
		_bstr_t strConnect = "Provider=SQLOLEDB;Server=DESKTOP-J4JFLTU\\SQLEXPRESS; Database=WangFirst; uid=sa; pwd=529147";
		m_pConnection->Open(strConnect, "", "", adModeUnknown);//NULL、adConnectUnspecified、//建立与服务器连接

		if(m_pConnection == NULL)
		{
			cerr << "Link data ERROR!\n";
		}

		m_pRecordset.CreateInstance(__uuidof(Recordset));//创建记录集对象

		//取得表中的记录
		//m_pRecordset->Open(bstrSQL, m_pConnection.GetInterfacePtr(), adOpenDynamic, adLockOptimistic, adCmdText);
		m_pRecordset->Open(bstrSQL, _variant_t((IDispatch *)m_pConnection, true), adOpenStatic, adLockReadOnly, adCmdText);


		cout << "学号          姓名          年龄   性别     专业";
		cout << "\n---------------------------------------------------\n";
		double data[5] = {0,0,0,0,0};
		data[0] = m_pRecordset->GetCollect(_variant_t((long)0));
		data[1] = m_pRecordset->GetCollect(_variant_t((long)1));
		data[2] = m_pRecordset->GetCollect(_variant_t((long)2));

		for (int i = 0; i < 5;i++)
		{
			cout << data[i] << "   ";
		}
		cout << endl;


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