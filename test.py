# -*- coding: utf-8 -*-
import sys,os
pathname, scriptname = os.path.split(sys.argv[0])
sys.path.append( os.path.join(os.path.abspath(pathname), r'MegaLinkInfoLib\bin\Debug'))

import clr
clr.AddReference('MegaLib')

from MegaLib import Mega

def sizeof_fmt(num, suffix='B'):
    for unit in ['','Ki','Mi','Gi','Ti','Pi','Ei','Zi']:
        if abs(num) < 1024.0:
            return "%3.1f%s%s" % (num, unit, suffix)
        num /= 1024.0
    return "%.1f%s%s" % (num, 'Yi', suffix)
    
url = 'https://mega.co.nz/#!poxTiIbZ!FExRZ1JWvM5BdxQPoPDmY0DbB_QxLeb-eS9-KfgV1RE'
info = Mega.GetUrlInfo(url)
print('''Filename: {0}
Size: {1}
Download URL: {2}
FileID: {3}
FileKey: {4}'''.format(info.Nombre, sizeof_fmt(info.Tamano), info.URL, info.FileID, info.FileKey))