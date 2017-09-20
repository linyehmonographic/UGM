#define _CRT_SECURE_NO_WARNINGS 1
#include <iostream>
#include <fstream>
#include <cstring>
#include <ctime>
#include <string>
#include <Windows.h>
#include <shellapi.h>
using namespace std;
int main(int argc, char **argv)
{
	
	ofstream logFile;
	
	SHELLEXECUTEINFO ShellInfo;
	ShellInfo.cbSize = sizeof(SHELLEXECUTEINFO);
	ShellInfo.fMask = SEE_MASK_NOCLOSEPROCESS;
	ShellInfo.hwnd = NULL;
	ShellInfo.lpVerb = "open";
	ShellInfo.lpFile = "adb";
	ShellInfo.lpParameters = NULL; //在下面修改
	ShellInfo.lpDirectory = NULL;
	ShellInfo.nShow = SW_SHOW;
	ShellInfo.hInstApp = NULL;

	string c;
	while (getline(cin, c))
	{
		size_t found = c.find("UGM");
		if (found != string::npos)
		{
			if ((found = c.find("UGM LogStart")) != string::npos)
			{
				cout << "Start to log!\n";
				string SceneName;
				int start = 0;
				for (int i = 0; i < c.length(); i++)
				{
					if (c[i] == ':')
					{
						start = i + 1;
					}
				}
				SceneName = c.substr(start, c.length() - start - 1); //最後的減1是因為反斜線r

				time_t nowtime = time(NULL);
				tm* time_ptr = localtime(&nowtime);
				string nowtime_str = "UGM_Log_" + to_string(time_ptr->tm_year + 1900) + "-" + to_string(time_ptr->tm_mon) + "-" + to_string(time_ptr->tm_mday) + "_" + to_string(time_ptr->tm_hour) + "-" + to_string(time_ptr->tm_min) + "-" + to_string(time_ptr->tm_sec);
				logFile.open(nowtime_str + "_" + SceneName + ".txt", ios::out);
				for (int i = 0; i < SceneName.length(); ++i)
				{
					if (SceneName[i] == ' ')
					{
						SceneName.insert(SceneName.begin() + i, '\\');
						++i;
					}
				}
				string shell_str = "shell screenrecord --time-limit 86400 /sdcard/UGM/" + nowtime_str + "_" + SceneName + ".mp4";
				ShellInfo.lpParameters = shell_str.c_str();

				if (!ShellExecuteEx(&ShellInfo))
				{
					cerr << "Cannot open adb screenrecord!\n";
					system("pause");
					exit(1);
				}
			}
			else if ((found = c.find("UGM LogEnd")) != string::npos)
			{
				TerminateProcess(ShellInfo.hProcess, 0);
				logFile.close();
			}
			cout << c << endl;
			logFile << c << endl;
		}
	}

	TerminateProcess(ShellInfo.hProcess, 0);
	logFile.close();

	system("pause");
	return 0;
}