@echo off
@set _util_cmd=C:\Inetpub\AdminScripts\adsutil.vbs

@set _vdir_name=%1
@set _vdir_AppFriendlyName=%1
@set _vdir_path=%2

@cscript %_util_cmd% delete w3svc/1/root/%_vdir_name%

@cscript %_util_cmd% create_vdir w3svc/1/root/%_vdir_name%
@cscript %_util_cmd% set w3svc/1/root/kk/path %_vdir_path%
@cscript %_util_cmd% set w3svc/1/root/kk/AppFriendlyName %_vdir_AppFriendlyName%

@cscript %_util_cmd% APPCREATEPOOLPROC w3svc/1/root/%_vdir_name%

@cscript %_util_cmd% set w3svc/1/root/%_vdir_name%/AccessRead True
@cscript %_util_cmd% set w3svc/1/root/%_vdir_name%/AccessWrite False

@cscript %_util_cmd% set w3svc/1/root/%_vdir_name%/AccessExecute True
@cscript %_util_cmd% set w3svc/1/root/%_vdir_name%/AccessScript False
@cscript %_util_cmd% set w3svc/1/root/%_vdir_name%/AccessSource True

@echo done...