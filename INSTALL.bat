@echo off
echo �v���W�F�N�g�X�N���v�g�̃C���X�g�[�����J�n���܂��c�c
git clone git@github.com:terapotan/projectScripts.git projectScripts
set USER_INPUT=
set /P USER_INPUT="�V�K�쐬�����������͂��Ă��������B>"
cd ./projectScripts
git checkout %USER_INPUT%
cd ../
python ./projectScripts/initialSetting.py

pause

del /f "%~dp0%~nx0"