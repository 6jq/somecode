#!/bin/sh
vncserver -kill :1
vncserver -geometry 800x600 -nolisten tcp :1
