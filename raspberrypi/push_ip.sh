#!/bin/bash
userkey='userkey'
url='http://localhost'
data='device=raspi'
cmd="curl --request POST --data '$data' --header user-key:$userkey $url"
echo $cmd | bash
exit 0

