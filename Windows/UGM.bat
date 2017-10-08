adb shell mkdir /sdcard/UGM
adb logcat -c
adb logcat -s Unity | UGM_LogWriter.exe
adb pull /sdcard/UGM
adb shell rm -rf /sdcard/UGM