##第三个版本 简化脚本
TARGET = .
CC = g++
CFLAGS = -g -lws2_32 -lwsock32 -D_HH  
CFLAGC = -c
INCLUDE = -I$(TARGET)
EXEC = $(TARGET)/Server
#搜索当前目录,生成由*.cpp结尾的文件列表,wildcard--函数名
SOURCE = $(wildcard *.cpp)
#用%.o替换$(SOURCE)中的%.cpp文件
OBJS = $(patsubst %.cpp,%.o,$(SOURCE))

 
all: $(EXEC)
Server:$(OBJS)
	$(CC) $(CFLAGS) $(INCLUDE) -o $@ $^
	@rm *.o
	@echo "<<<<<< $@ is created successfully! >>>>>>"

##添加文件编译规则
$(OBJS):%o:%cpp
	$(CC) $(CFLAGC) $< -o $@

.PHONY: clean

clean:
	rm *.exe

