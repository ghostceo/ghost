#!/usr/bin/env python
import os


def get_ip_and_passwd(fpath):
    return map(str.split, open(fpath).read().strip().split('\n'))


def main():
    fpath = './hosts.txt'
    for line in get_ip_and_passwd(fpath):
        if not line or line[0].startswith('#'):
            continue
	ip, port, user, old_passwd, new_passwd = line
        print '-' * 80
        print 'change password for %s@%s' % (user, ip)
        os.system('./chpasswd.exp %s %s %s %s %s' % (ip, port, user, old_passwd, new_passwd))


if __name__ == '__main__':
    main()
