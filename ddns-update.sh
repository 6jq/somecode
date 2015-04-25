#/bin/bash
myip=`curl http://1111.ip138.com/ic.asp | grep '\[[0-9]*.[0-9]*.[0-9]*.[0-9]*\]' | cut -d\[ -f 2 | cut -d\] -f 1`
myhost='raspi99.ddns.net'
username='lube00'
password='123456'
curl "http://$username:$password@dynupdate.no-ip.com/nic/update?hostname=$myhost&myip=$myip"
