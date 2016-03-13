#/bin/bash
myip=`wget http://ipinfo.io/ip -O - -q`
myhost='raspicc.ddns.net'
username='username'
password='password'
wget "http://$username:$password@dynupdate.no-ip.com/nic/update?hostname=$myhost&myip=$myip" -O - -q
