#!/bin/bash
if [ $# -ne 1 ]; then
	echo "ERROR! usage: $0 login|logout"
	exit 1;
elif [ "$1" = "login" ]; then
	curl -d "username=lujingquan&password=123456&language=1&actionType=umlogin&userIpMac="\
	http://172.16.3.1:8888 > /dev/null 2>&1
	echo "login"
elif [ "$1" = "logout" ]; then
	curl -d "language=1&actionType=umlogout" http://172.16.3.1:8888 > /dev/null 2>&1
	echo "logout"
else
	echo "ERROR"
	exit 1
fi
exit 0
