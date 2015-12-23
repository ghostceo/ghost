#!/bin/sh
here=`which "$0" 2>/dev/null || echo .`
base="`dirname $here`"
SHELL_DIR=`(cd "$base"; echo $PWD)`
rm -rf makefile
cp -r $base/linux/makefile $base
make