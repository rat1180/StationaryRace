using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
�v���p�e�B	                     �@�\

Mass	                    :�z�C�[���̎��ʁB

Radius	                    :�z�C�[���̔��a�B

Wheel Damping Rate	        :�z�C�[���ɓK�p����錸���l�ł��B

Suspension Distance	        :�z�C�[���T�X�y���V�����̍ő剄�������ŁA���[�J����Ԃő��肳��܂��B
                             �T�X�y���V�����͏�Ƀ��[�J���� Y ����ʂ��ĉ��ɐL�т܂��B

Force App Point Distance	:���̃p�����[�^�[�́A�z�C�[���̗͂��K�p�����ʒu���`���܂��B
                             ����́A�z�C�[���̊�ƂȂ�Î~�ʒu���烁�[�g���P�ʂŃT�X�y���V�����̐i�s�����ɉ��������Ғl��ݒ肵�܂��B
                            �uforceAppPointDistance = 0�v�̂Ƃ��A�͂̓z�C�[���̊�ƂȂ�Î~�ʒu�œK�p����܂��B
                             ��ʓI�Ɏԗ��̏d�S��菭�����œK�p���܂��B

Center	                    :�I�u�W�F�N�g�̃��[�J����Ԃł̃z�C�[���̒��S�B

Suspension Spring	        :�T�X�y���V�������A�X�v�����O�ƌ����͂�ǉ����āATarget Position �ɒB���悤�Ƃ��܂��B

Spring	                    :�X�v�����O�͂� Target Position �ɓ��B���悤�Ƃ��܂��B
                             �l���傫���قǁA�T�X�y���V������ Target Position �ɓ��B���鑬�x���オ��܂��B

Damper	                    :�T�X�y���V�����̑��x���������܂��B�l���������ق� Suspension Spring �̑��x��������܂��B

Target Position	            :Suspension Distance �ɉ������T�X�y���V�����̎c��̋����B
                             1 �́A���S�ɐL�т������T�X�y���V�������}�b�s���O���A0 �͊��S�ɏk�܂����T�X�y���V�������}�b�s���O���܂��B
                             �f�t�H���g�� 0.5 �ŁA�ʏ�̎ԗ��̃T�X�y���V�����̓���Ɉ�v���܂��B

Forward/Sideways Friction	:Forward/Sideways Friction �z�C�[�����O�]�≡�]����ۂ̃^�C���̖��C�̃v���p�e�B�B

Extremum Slip/Value	        :�Ȑ��̋ɒl�_�B

Asymptote Slip/Value	    :���C�Ȑ��̑Q�ߐ��̃X���b�v�A����уt�H�[�X�l

Stiffness	                :Extremum Value �� Asymptote Value �ɑ΂���搔 (�f�t�H���g�� 1)�B���C�̍�����ω������܂��B
                             ����� 0 �ɐݒ肷��ƁA�z�C�[������̂��ׂĂ̖��C�����S�ɖ����ɂȂ�܂��B
                             �ʏ�A�����^�C�����ɍ������C�����āA�X�N���v�g����e��n�Սޗ����V�~�����[�g���܂��B
 
 */