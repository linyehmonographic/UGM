adb shell mkdir /sdcard/UGM
adb logcat -c
adb logcat -s Unity | UGM_LogWriter.exe
::adb pull /sdcard/UGM
::#CRASH#adb shell -rf /sdcard/UGM