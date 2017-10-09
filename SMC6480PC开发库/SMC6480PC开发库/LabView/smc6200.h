/********************************** SMC6系列PC开发库  ************************************************
**--------------文件信息--------------------------------------------------------------------------------
**文件名: smc6x.h
**创建人: 郑孝洋
**时间: 20080725
**描述: 用户接口C++头文件, 必须采用C++语法调用。

**------------修订历史记录----------------------------------------------------------------------------
** 修改人: 郑孝洋
** 版  本: 1.0
** 日　期: 20081017
** 描　述: 版本建立
**
**------------------------------------------------------------------------------------------------------



********************************************************************************************************/


#ifndef _SMC6200_PC_INCLUDE_H
#define _SMC6200_PC_INCLUDE_H

#define __SMC6200_EXPORTS

//定义输入和输出
#ifdef __SMC6200_EXPORTS
#define SMC6200API __declspec(dllexport)
#else
#define SMC6200API __declspec(dllimport)
#endif

#ifdef __cplusplus
extern "C" {
#endif 

/*********************************************************
数据类型定义
**********************************************************/

//特殊的定义加在这里
typedef unsigned __int64   uint64;  

//特殊的定义加在这里
typedef __int64   int64;  

//#define BYTE           INT8U
//#define WORD           INT16U
//#define DWORD          INT32U

typedef unsigned char  BYTE;
typedef unsigned short  WORD;
//typedef unsigned int  DWORD;

//#define __stdcall 

typedef unsigned char  uint8;                   /* defined for unsigned 8-bits integer variable     无符号8位整型变量  */
typedef signed   char  int8;                    /* defined for signed 8-bits integer variable        有符号8位整型变量  */
typedef unsigned short uint16;                  /* defined for unsigned 16-bits integer variable     无符号16位整型变量 */
typedef signed   short int16;                   /* defined for signed 16-bits integer variable         有符号16位整型变量 */
typedef unsigned int   uint32;                  /* defined for unsigned 32-bits integer variable     无符号32位整型变量 */
typedef signed   int   int32;                   /* defined for signed 32-bits integer variable         有符号32位整型变量 */
typedef float          fp32;                    /* single precision floating point variable (32bits) 单精度浮点数（32位长度） */
typedef double         fp64;                    /* double precision floating point variable (64bits) 双精度浮点数（64位长度） */
typedef unsigned int   uint;                  /* defined for unsigned 32-bits integer variable     无符号32位整型变量 */




#ifndef TRUE
#define TRUE  1
#endif

#ifndef FALSE
#define FALSE 0
#endif

#ifndef true
#define true  1
#endif

#ifndef false
#define false 0
#endif


#ifndef NULL
#define NULL 0                   /* see <stddef.h> */
#endif



//用于对字节按位进行操作
union un_byte {                                        /*   */
              unsigned char BYTE;                       /*  Byte Access */
              struct {                                  /*  Bit  Access */
                     unsigned char B0:1;                /*    Bit 7     */
                     unsigned char B1:1;                /*    Bit 6     */
                     unsigned char B2:1;                /*    Bit 5     */
                     unsigned char B3:1;                /*    Bit 4     */
                     unsigned char B4:1;                /*    Bit 3     */
                     unsigned char B5:1;                /*    Bit 2     */
                     unsigned char B6:1;                /*    Bit 1     */
                     unsigned char B7:1;                /*    Bit 0     */
                     }      BIT;                        /*              */
};                                                      /*              */

union un_uint16 {                                        /*   */
              uint16 m_UINT;                       /*  Byte Access */
              struct {                                  /*  Bit  Access */
                  unsigned short B0:1;                /*    Bit 1     */
                  unsigned short B1:1;                /*    Bit 2     */
                  unsigned short B2:1;                /*    Bit 3     */
                  unsigned short B3:1;                /*    Bit 4     */
                  unsigned short B4:1;                /*    Bit 5     */
                  unsigned short B5:1;                /*    Bit 6     */
                  unsigned short B6:1;                /*    Bit 7     */
                  unsigned short B7:1;                /*    Bit 8     */
                  
                  unsigned short B8:1;                /*    Bit 9     */
                  unsigned short B9:1;                /*    Bit 10     */
                  unsigned short B10:1;                /*    Bit 11     */
                  unsigned short B11:1;                /*    Bit 12     */
                  unsigned short B12:1;                /*    Bit 13     */
                  unsigned short B13:1;                /*    Bit 14     */
                  unsigned short B14:1;                /*    Bit 15     */
                  unsigned short B15:1;                /*    Bit 16     */
                     }      BIT;                        /*              */
};  


union un_uint32 {                                        /*   */
              uint32 m_UINT32;                       /*  Byte Access */
              struct {                                  /*  Bit  Access */
                  unsigned int B0:1;                /*    Bit 7     */
                  unsigned int B1:1;                /*    Bit 6     */
                  unsigned int B2:1;                /*    Bit 5     */
                  unsigned int B3:1;                /*    Bit 4     */
                  unsigned int B4:1;                /*    Bit 3     */
                  unsigned int B5:1;                /*    Bit 2     */
                  unsigned int B6:1;                /*    Bit 1     */
                  unsigned int B7:1;                /*    Bit 0     */
                  
                  unsigned int B8:1;                /*    Bit 7     */
                  unsigned int B9:1;                /*    Bit 6     */
                  unsigned int B10:1;                /*    Bit 5     */
                  unsigned int B11:1;                /*    Bit 4     */
                  unsigned int B12:1;                /*    Bit 3     */
                  unsigned int B13:1;                /*    Bit 2     */
                  unsigned int B14:1;                /*    Bit 1     */
                  unsigned int B15:1;                /*    Bit 0     */

                  unsigned int B16:1;                /*    Bit 7     */
                  unsigned int B17:1;                /*    Bit 6     */
                  unsigned int B18:1;                /*    Bit 5     */
                  unsigned int B19:1;                /*    Bit 4     */
                  unsigned int B20:1;                /*    Bit 3     */
                  unsigned int B21:1;                /*    Bit 2     */
                  unsigned int B22:1;                /*    Bit 1     */
                  unsigned int B23:1;                /*    Bit 0     */
                  
                  unsigned int B24:1;                /*    Bit 7     */
                  unsigned int B25:1;                /*    Bit 6     */
                  unsigned int B26:1;                /*    Bit 5     */
                  unsigned int B27:1;                /*    Bit 4     */
                  unsigned int B28:1;                /*    Bit 3     */
                  unsigned int B29:1;                /*    Bit 2     */
                  unsigned int B30:1;                /*    Bit 1     */
                  unsigned int B31:1;                /*    Bit 0     */
                  
                     }      BIT;                        /*              */
};  



//
// 连接类型, 6200可以用串口与网口
enum SMC6X_CONNECTION_TYPE
{
    SMC6X_CONNECTION_COM = 1,
    SMC6X_CONNECTION_ETH = 2,
    SMC6X_CONNECTION_USB = 3,
    SMC6X_CONNECTION_PCI = 4,
};

//缺省的等待时间
#define SMC6X_DEFAULT_TIMEOUT   5000

//串口延时需要更加长一些
#define SMC6X_DEFAULT_TIMEOUT_COM   10000



typedef  void* SMCHANDLE;




//
//返回错误码
#ifndef ERR_SUCCESS
#define ERR_SUCCESS  0
#endif
#ifndef ERR_OK
#define ERR_OK  0
#endif

enum ERR_CODE_SMC6X
{
    ERRCODE_UNKNOWN = 1,
    ERRCODE_PARAERR = 2,        
    ERRCODE_TIMEOUT = 3,
    ERRCODE_CONTROLLERBUSY = 4,
    ERRCODE_CONNECT_TOOMANY = 5,

    ERRCODE_OS_ERR = 6,
    ERRCODE_CANNOT_OPEN_COM = 7,
    ERRCODE_CANNOT_CONNECTETH = 8,
    ERRCODE_HANDLEERR = 9, //链接错误
    ERRCODE_SENDERR = 10, //链接错误
    ERRCODE_GFILE_ERR = 11, //G文件语法错误
    ERRCODE_FIRMWAREERR = 12, //固件文件错误

    ERRCODE_FILENAME_TOOLONG = 13, //文件名太长
    ERRCODE_FIRMWAR_MISMATCH = 14, //固件文件不匹配

    ERRCODE_CARD_NOTSUPPORT = 15, //对应的卡不支持这个功能


    ERRCODE_BUFFER_TOO_SMALL = 15, //输入的缓冲太小
    ERRCODE_NEED_PASSWORD = 16,    //密码保护
    ERRCODE_PASSWORD_ENTER_TOOFAST = 17,    //密码输入太快



    ERRCODE_GET_LENGTH_ERR = 100, //收到的数据包的长度错误， 这个测试完成后不会出现, 字符串接口时可能超过缓冲长度

    ERRCODE_COMPILE_OFFSET = 1000, //文件编译错误


    ERRCODE_CONTROLLERERR_OFFSET = 100000, //控制器上面传来的错误，加上这个偏移

};

/*********************************************************
系统状态定义
**********************************************************/
#define  SYS_STATE_IDLE        1 //待机
//#define  SYS_STATE_ORIGINING  2 回零的状态不好确定回零完成，不要这个状态；
#define  SYS_STATE_GRUNNING    3  //运行
#define  SYS_STATE_MANUALING   4  //手动
#define  SYS_STATE_PAUSE       5 //暂停
#define  SYS_STATE_GEDIT       6 //程序编辑
#define  SYS_STATE_SETTING     7 //设置

#define  SYS_STATE_TEST        8 //测试
#define  SYS_STATE_GFILEREVIEW 9 //gfile 浏览
#define  SYS_STATE_UDISK       10 //U盘操作
#define  SYS_STATE_GTEACHING   11 //示教

//新增加
#define  SYS_STATE_CANNOT_CONNECT   50 //链接不上


//G代码运行停止的错误码
#define ERR_GSTOP_OFFSET        2000
#define ERR_GSTOP_EMG           (ERR_GSTOP_OFFSET + 1)          //EMG停止
#define ERR_GSTOP_EL            (ERR_GSTOP_OFFSET + 2)          //限位停止
#define ERR_GSTOP_GFILE_TYPE_ERR     (ERR_GSTOP_OFFSET + 3)     //类型出错
#define ERR_GSTOP_STOPKEYDOWN     (ERR_GSTOP_OFFSET + 4)        //停止键按下，不能启动
#define ERR_GSTOP_LOOPERR       (ERR_GSTOP_OFFSET + 5)          //循环出错, 次数过多
#define ERR_GSTOP_SUBERR        (ERR_GSTOP_OFFSET + 6)          //子程序调用出错, 层次过多等
#define ERR_GSTOP_NLINEERR      (ERR_GSTOP_OFFSET + 7)          //对应N行号找不到
#define ERR_GSTOP_NOTSUPPORT     (ERR_GSTOP_OFFSET + 8)         //不支持的G代码
#define ERR_GSTOP_FILEEND       (ERR_GSTOP_OFFSET + 9)          //文件异常结束
#define ERR_GSTOP_SOFTLIMITED     (ERR_GSTOP_OFFSET + 10)       //软限位停止
#define ERR_GSTOP_GLINE_PARA_ERR     (ERR_GSTOP_OFFSET + 11)    //参数等出错
#define ERR_GSTOP_TASKERR       (ERR_GSTOP_OFFSET + 12)         //多任务过多
#define ERR_GSTOP_USER_FORCEEND     (ERR_GSTOP_OFFSET + 13)     //强制停止
#define ERR_GSTOP_GFILECHECKERR     (ERR_GSTOP_OFFSET + 14)     //g文件检查错误
#define ERR_GSTOP_GFILEIDERR     (ERR_GSTOP_OFFSET + 15)        //g文件号错误
#define ERR_GSTOP_ALM              (ERR_GSTOP_OFFSET + 16)      //g文件号错误
#define ERR_GSTOP_ENCODE      (ERR_GSTOP_OFFSET + 17)      //g文件号错误
#define ERR_GSTOP_UNKNOWN     (ERR_GSTOP_OFFSET + 30)           //不可能的错误




/*********************************************************
函数声明
**********************************************************/

/*************************************************************
说明：与控制器建立链接
输入：无
输出：卡链接handle
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCOpen(SMC6X_CONNECTION_TYPE type, char *pconnectstring ,SMCHANDLE * phandle);

/*************************************************************
说明：与控制器建立链接
输入：无
输出：卡链接handle
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCOpenCom(uint comid, SMCHANDLE * phandle);

/*************************************************************
说明：与控制器建立链接
输入：IP地址，字符串的方式输入
输出：卡链接handle
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCOpenEth(char *ipaddr, SMCHANDLE * phandle);

/*************************************************************
说明：与控制器建立链接
输入：IP地址，32位数的IP地址输入, 注意字节顺序
输出：卡链接handle
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCOpenEth2(struct in_addr straddr, SMCHANDLE * phandle);


/*************************************************************
说明：关闭控制器链接
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCClose(SMCHANDLE  handle);

/*************************************************************
说明：命令的延时等待时间
输入：卡链接handle 毫秒时间
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetTimeOut(SMCHANDLE  handle, uint32 timems);

/*************************************************************
说明：命令的延时等待时间
输入：卡链接handle 
输出：毫秒时间
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetTimeOut(SMCHANDLE  handle, uint32* ptimems);

/*************************************************************
说明：读取长时间命令的进度
输入：卡链接handle 
输出：
返回值：进度， 浮点， 
*************************************************************/
float  __stdcall SMCGetProgress(SMCHANDLE  handle);


#if 0
#endif
/**********************************************

	command 函数列表

*******************************************/


/*************************************************************
说明：//读取系统状态
输入：卡链接handle
输出：状态
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetState(SMCHANDLE handle,uint8 *pstate);

/*************************************************************
说明：//读取链接控制器的轴数
输入：卡链接handle
输出：
返回值：轴数，出错0
*************************************************************/
uint8 __stdcall SMCGetAxises(SMCHANDLE handle);

/*************************************************************
说明：下载程序文件 下载前会编译一次
输入：卡链接handle 文件名
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownProgram(SMCHANDLE handle, const char* pfilename, const char* pfilenameinControl);

/*************************************************************
说明：下载程序文件 下载前会编译一次
输入：卡链接handle buff 控制器上文件的名字
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownMemProgram(SMCHANDLE handle, const char* pbuffer, uint32 buffsize, const char* pfilenameinControl);


/*************************************************************
说明：下载程序文件 到临时文件中
输入：卡链接handle buff 控制器上文件的名字
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownProgramToTemp(SMCHANDLE handle, const char* pfilename);

/*************************************************************
说明：下载程序文件 到临时文件中
输入：卡链接handle buff 控制器上文件的名字
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownMemProgramToTemp(SMCHANDLE handle, const char* pbuffer, uint32 buffsize);


/*************************************************************
说明：运行
输入：卡链接handle 文件名， 当为NULL的时候运行缺省文件
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCRunProgramFile(SMCHANDLE handle, const char* pfilenameinControl);

/*************************************************************
说明：下载到ram中运行
输入：卡链接handle 文件名
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownProgramToRamAndRun(SMCHANDLE handle, const char* pfilename);

/*************************************************************
说明：下载到ram中运行
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownMemProgramToRamAndRun(SMCHANDLE handle, const char* pbuffer, uint32 buffsize);

/*************************************************************
说明：上传程序文件
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpProgram(SMCHANDLE handle, const char* pfilename, const char* pfilenameinControl);
/*************************************************************
说明：上传程序文件
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpProgramToMem(SMCHANDLE handle, char* pbuffer, uint32 buffsize, char* pfilenameinControl, uint32* puifilesize);





/*************************************************************
说明：暂停
输入：卡链接handle 文件名， 当为NULL的时候运行缺省文件
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCPause(SMCHANDLE handle);

/*************************************************************
说明：停止
输入：卡链接handle 文件名， 当为NULL的时候运行缺省文件
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCStop(SMCHANDLE handle);

/*************************************************************
说明：运行临时文件
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCRunTempFile(SMCHANDLE handle);

/*************************************************************
说明：读取剩余空间
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCCheckRemainProgramSpace(SMCHANDLE handle, uint32 * pRemainSpaceInKB);

/*************************************************************
说明：读取程序停止原因
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCCheckProgramStopReason(SMCHANDLE handle, uint32 * pStopReason);
/*************************************************************
说明：读取程序当前行
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetCurRunningLine(SMCHANDLE handle, uint32 * pLineNum);

/*************************************************************
说明：设置单步运行，这个实时修改状态，重启后丢失
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetStepRun(SMCHANDLE handle, uint8 bifStep);

/*************************************************************
说明：设置空走，这个实时修改状态，重启后丢失
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetRunNoIO(SMCHANDLE handle, uint8 bifVainRun);

/*************************************************************
说明：读取设置
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetRunningOption(SMCHANDLE handle, uint8* bifStep, uint8* bifVainRun);


/*************************************************************
说明：继续运行
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCContinueRun(SMCHANDLE handle);

/*************************************************************
说明：检查文件是否存在
输入：卡链接handle 控制器上文件名，不带扩展
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCCheckProgramFile(SMCHANDLE handle, const char* pfilenameinControl, uint8 *pbIfExist, uint32 *pFileSize);

/*************************************************************
说明：查找控制器上的文件， 文件名为空表示文件不不存在
输入：卡链接handle 控制器上文件名，不带扩展
输出： 是否存在 文件大小
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCFindFirstProgramFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);

/*************************************************************
说明：查找控制器上的文件， 文件名为空表示文件不不存在
输入：卡链接handle 控制器上文件名，不带扩展
输出： 是否存在 文件大小
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCFindNextProgramFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);

/*************************************************************
说明：查找控制器上的当前文件
输入：卡链接handle 控制器上文件名，不带扩展
输出： 是否存在 文件大小(暂时不支持)
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetCurProgramFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);

/*************************************************************
说明：删除控制器上的文件
输入：卡链接handle 控制器上文件名，不带扩展
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDeleteProgramFile(SMCHANDLE handle, const char* pfilenameinControl);

/*************************************************************
说明：删除控制器上的文件
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCRemoveAllProgramFiles(SMCHANDLE handle);


#if 0
/***********************  设置部分  ************************/
#endif

/*************************************************************
说明：通用的字符串接口
输入：卡链接handle 发送字符串，接收字符串， 接收字符串长度, 当不想要应答时，把uiResponseLength = 0
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCCommand(SMCHANDLE handle, const char* pszCommand, char* psResponse, uint32 uiResponseLength);
/*************************************************************
说明：当前设置存盘
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCBurnSetting(SMCHANDLE handle);

/*************************************************************
说明：下载设置文件
输入：卡链接handle 文件名
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownSetting(SMCHANDLE handle, const char* pfilename);

/*************************************************************
说明：下载设置文件
输入：卡链接handle buff 
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownMemSetting(SMCHANDLE handle, const char* pbuffer, uint32 buffsize);

/*************************************************************
说明：上传设置
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpSetting(SMCHANDLE handle, const char* pfilename);
/*************************************************************
说明：上传设置
输入：卡链接handle 内存buff 返回实际的文件长度
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpSettingToMem(SMCHANDLE handle, char* pbuffer, uint32 buffsize, uint32* puifilesize);


/*************************************************************
说明：下载设置文件
输入：卡链接handle 文件名
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownDefaultSetting(SMCHANDLE handle, const char* pfilename);
/*************************************************************
说明：下载设置文件, 文本文件的长度用strlen 即可
输入：卡链接handle buff 
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownMemDefaultSetting(SMCHANDLE handle, const char* pbuffer, uint32 buffsize);

/*************************************************************
说明：上传设置
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpDefaultSetting(SMCHANDLE handle, const char* pfilename);

/*************************************************************
说明：上传设置
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpDefaultSettingToMem(SMCHANDLE handle, char* pbuffer, uint32 buffsize, uint32* puifilesize);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetIpAddr(SMCHANDLE handle, const char* sIpAddr, const char* sGateAddr, const char* sMask, uint8 bifdhcp);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetIpAddr(SMCHANDLE handle, char* sIpAddr, char* sGateAddr, char* sMask, uint8 *pbifdhcp);

/*************************************************************
说明：读取当前控制器的IP地址, 注意:当设置dhcp以后，设置的IP与实际的不一致。
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetCurIpAddr(SMCHANDLE handle, char* sIpAddr);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetZeroSpeed(SMCHANDLE handle, uint8 iaxis, uint32 uiSpeed);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetZeroSpeed(SMCHANDLE handle, uint8 iaxis, uint32* puiSpeed);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetLocateSpeed(SMCHANDLE handle, uint8 iaxis, uint32 uiSpeed);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetLocateSpeed(SMCHANDLE handle, uint8 iaxis, uint32* puiSpeed);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetLocateStartSpeed(SMCHANDLE handle, uint8 iaxis, uint32 uiSpeed);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetLocateStartSpeed(SMCHANDLE handle, uint8 iaxis, uint32* puiSpeed);


/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetLocateAcceleration(SMCHANDLE handle, uint8 iaxis, uint32 uiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetLocateAcceleration(SMCHANDLE handle, uint8 iaxis, uint32* puiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetLocateDeceleration(SMCHANDLE handle, uint8 iaxis, uint32 uiValue);
/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetLocateDeceleration(SMCHANDLE handle, uint8 iaxis, uint32* puiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetUnitPulses(SMCHANDLE handle, uint8 iaxis, uint32 uiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetUnitPulses(SMCHANDLE handle, uint8 iaxis, uint32* puiValue);


/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetVectStartSpeed(SMCHANDLE handle, uint32 uiValue);
/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetVectStartSpeed(SMCHANDLE handle, uint32* puiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetVectSpeed(SMCHANDLE handle, uint32 uiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetVectSpeed(SMCHANDLE handle, uint32* puiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetVectAcceleration(SMCHANDLE handle, uint32 uiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetVectAcceleration(SMCHANDLE handle, uint32* puiValue);


/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetVectDeceleration(SMCHANDLE handle, uint32 uiValue);

/*************************************************************
说明：参数函数
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetVectDeceleration(SMCHANDLE handle, uint32* puiValue);



#if 0
/***********************  运动部分  ************************/
#endif


//特殊轴号定义
enum SMC_AXIS_NUM_LIST
{
    SMC_AXIS_X = 0,
    SMC_AXIS_Y = 1,
    SMC_AXIS_Z = 2,
    SMC_AXIS_U = 3,

    SMC_AXIS_NUM_VECT = 0XFE,
    SMC_AXIS_NUM_ALL = 0XFF,
};

/*************************************************************
说明：
输入：卡链接handle 轴号， 长度， 是否绝对移动
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCPMove(SMCHANDLE handle, uint8 iaxis, double dlength, uint8 bIfAbs);

/*************************************************************
说明：
输入：卡链接handle 轴号， 长度， 是否绝对移动
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCPMovePluses(SMCHANDLE handle, uint8 iaxis, int32 ilength, uint8 bIfAbs);

/*************************************************************
说明：
输入：卡链接handle 轴号， 方向
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVMove(SMCHANDLE handle, uint8 iaxis, uint8 bIfPositiveDir);


/*************************************************************
说明：
输入：卡链接handle 轴号， 方向
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCPMoveList(SMCHANDLE handle,uint8 itotalaxises, uint8 *puilineaxislist, uint32 uisteps, double *pDistanceList, uint8 bIfAbs);



/*************************************************************
说明：
输入：卡链接handle 轴号， 方向
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCCheckDown(SMCHANDLE handle,uint8 iaxis, uint8* pbIfDown);

/*************************************************************
说明：回零，回零模式通过参数指定
输入：卡链接handle 轴号， 方向
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCHomeMove(SMCHANDLE handle,uint8 iaxis);

/*************************************************************
说明：
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCIfHomeMoveing(SMCHANDLE handle,uint8 iaxis, uint8* pbIfHoming);

/*************************************************************
说明：
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDecelStop(SMCHANDLE handle,uint8 iaxis);

/*************************************************************
说明：
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCImdStop(SMCHANDLE handle,uint8 iaxis);


/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCEmgStop(SMCHANDLE handle);

/*************************************************************
说明：变速度
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCChangeSpeed(SMCHANDLE handle,uint8 iaxis, double dspeed);


/*************************************************************
说明：
输入：卡链接handle 轴号
输出：坐标
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetPosition(SMCHANDLE handle,uint8 iaxis, double* pposition);


/*************************************************************
说明： 读取当前的工件坐标
输入：卡链接handle 轴号
输出：坐标
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetWorkPosition(SMCHANDLE handle,uint8 iaxis, double* pposition);

/*************************************************************
说明： 读取机械坐标，脉冲方式
输入：卡链接handle 轴号
输出：坐标
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetPositionPulses(SMCHANDLE handle,uint8 iaxis, int32* pposition);

/*************************************************************
说明： 读取工件零点
输入：卡链接handle 轴号
输出：坐标
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetWorkOriginPosition(SMCHANDLE handle, uint8 iaxis, double* pposition);

/*************************************************************
说明：
输入：卡链接handle 轴号 坐标
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetPosition(SMCHANDLE handle,uint8 iaxis, double dposition);
/*************************************************************
说明：
输入：卡链接handle 轴号 坐标
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetPositionPulses(SMCHANDLE handle,uint8 iaxis, int32 iposition);

/*************************************************************
说明：
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWaitDown(SMCHANDLE handle,uint8 iaxis);

/*************************************************************
说明：
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWaitPoint(SMCHANDLE handle,uint8 iaxis, double dpos);

/*************************************************************
说明：
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCHandWheelSet(SMCHANDLE handle,uint8 iaxis, uint16 imulti, uint8 bifDirReverse);
/*************************************************************
说明：
输入：卡链接handle 轴号
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCHandWheelMove(SMCHANDLE handle,uint8 iaxis, uint8 bifenable);


/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveStart(SMCHANDLE handle);

/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveEnd(SMCHANDLE handle);

// 插补运行状态, 一旦启动，就会进入暂停状态
enum SMC6X_VECTMOVE_STATE
{
    VECTMOVE_STATE_RUNING = 1,
    VECTMOVE_STATE_PAUSE = 2,
    VECTMOVE_STATE_STOP = 3,
};

/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetVectMoveState(SMCHANDLE handle, uint8 *pState);

/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetVectMoveRemainSpace(SMCHANDLE handle, uint32 *pSpace);

/*************************************************************
说明：插补，会修改速度设置
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveLine1(SMCHANDLE handle, uint8 iaxis, double Distance, double dspeed, uint8 bIfAbs);
/*************************************************************
说明：插补，会修改速度设置
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveLine2(SMCHANDLE handle, uint8 iaxis1, double Distance1, uint8 iaxis2, double Distance2, double dspeed, uint8 bIfAbs);

/*************************************************************
说明：插补，不会修改速度设置
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveLineN(SMCHANDLE handle, uint8 itotalaxis, uint8* piaxisList, double* DistanceList, double dspeed, uint8 bIfAbs);

/*************************************************************
说明：插补，会修改速度设置
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveMultiLine2(SMCHANDLE handle, uint8 iaxis1, uint8 iaxis2, uint16 uiSectes, double* DistanceList, double* dspeedList, uint8 bIfAbs);

/*************************************************************
说明：插补，不会修改速度设置
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveMultiLineN(SMCHANDLE handle, uint8 itotalaxis, uint8* piaxisList, uint16 uiSectes,double* DistanceList, double* dspeedList, uint8 bIfAbs);

/*************************************************************
说明：插补，会修改速度设置
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveArc(SMCHANDLE handle, uint8 iaxis1, uint8 iaxis2, double Distance1, double Distance2, double Center1, double Center2, uint8 bIfAnticlockwise, double dspeed, uint8 bIfAbs);


/*************************************************************
说明：减速点加入
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveSetSpeedLimition(SMCHANDLE handle, double dspeed);


/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWaitVectLength(SMCHANDLE handle, double vectlength);

/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetCurRunVectLength(SMCHANDLE handle, double* pvectlength);
/*************************************************************
说明：
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetCurSpeed(SMCHANDLE handle, uint8 iaxis, double* pspeed);

/*************************************************************
说明： 运行暂停, 插补暂停后仍然可以加入小段
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMovePause(SMCHANDLE handle);

/*************************************************************
说明： 插补运行停止
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCVectMoveStop(SMCHANDLE handle);


/*************************************************************
说明：暂停; 这个函数功能暂不支持
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCAxisPause(SMCHANDLE handle, uint8 iaxis);

#if 0
/***********************  IO等接口部分  ************************/
#endif

//输入宏
#define    SMC_IN_VALIDVALUE      0    //有效电平，通用IO为低电平, 原点限位信号的电平可以设置
#define    SMC_IN_INVALIDVALUE    1    //高电平

//输出宏
#define    SMC_OUT_VALIDVALUE      0    //有效电平，通用IO为低电平, 当切换初始电平后，输出电平会相反
#define    SMC_OUT_INVALIDVALUE    1    //高电平

//所有的IO编号，包括浮点IO
enum enu_SMC_IONUM
{
    //普通IO从1开始编号
    SMC_IONUM_1 = 1, 

    SMC_IONUM_24 = 24, 

    //pwm与da也编号
    SMC_IONUM_PWM1 = 41,
    SMC_IONUM_PWM2 = 42,
    SMC_IONUM_DA1 = 51,
    SMC_IONUM_DA2 = 52,

    //用于操作LED    
    SMC_IONUM_LED1 = 61,
    SMC_IONUM_LED2 = 62,
    
    //用于操作PWM的频率
    SMC_IONUM_PWM1_FREQENCY = 71,
    SMC_IONUM_PWM2_FREQENCY = 72,

};


typedef struct
{
    uint8 m_axisnum;
    
    uint8 m_HomeState;
    uint8 m_AlarmState;
    
    uint8 m_SDState;
    uint8 m_INPState;
    
    uint8 m_ElDecState;
    uint8 m_ElPlusState;
    
    uint8 m_HandWheelAState;
    uint8 m_HandWheelBState;
    uint8 m_EncodeAState; //6200没有这个信号
    uint8 m_EncodeBState; //6200没有这个信号
    //uint8 m_EMGState; //每个轴都一样

    uint8 m_ClearState; //6200没有这个信号

    //增加软限位信号
    uint8 m_SoftElDecState; //0- 有效
    uint8 m_SoftElPlusState;
    uint8 m_LatchState;
}struct_AxisStates;


/*************************************************************
说明：点亮LED，或者灭掉
输入：卡链接handle led编号，从1开始
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWriteLed(SMCHANDLE handle, uint16 iLedNum, uint8 bifLighten);


/*************************************************************
说明：写输出口
输入：卡链接handle io编号，从1开始 0-低电平， 1- 高电平
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWriteOutBit(SMCHANDLE handle, uint16 ioNum, uint8 IoState);

/*************************************************************
说明：读输入口
输入：卡链接handle io编号，从1开始
输出：0-低电平， 1- 高电平
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadInBit(SMCHANDLE handle, uint16 ioNum, uint8* pIoState);

/*************************************************************
说明：读输出口
输入：卡链接handle io编号，从1开始
输出：0-低电平， 1- 高电平
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadOutBit(SMCHANDLE handle, uint16 ioNum, uint8* pIoState);

/*************************************************************
说明：写全部输出口
输入：卡链接handle 
      IoMask: 1的位要修改，可以通过这个参数修改指定几个IO
      IoState:  0-低电平， 1- 高电平;  0-31位 代表 1-32IO
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWriteOutPort(SMCHANDLE handle, uint32 IoMask, uint32 IoState);

/*************************************************************
说明：读全部输入口
输入：卡链接handle 
输出：0-低电平， 1- 高电平
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadInPort(SMCHANDLE handle, uint32* pIoState);

/*************************************************************
说明：读全部输出口
输入：卡链接handle 
输出：0-低电平， 1- 高电平
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadOutPort(SMCHANDLE handle, uint32* pIoState);


/*************************************************************
说明：读伺服告警输入状态 6200没有
输入：卡链接handle io编号，从1开始
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadAlarmState(SMCHANDLE handle, uint8 iaxis, uint8* pIoState);

/*************************************************************
说明：读原点输入状态
输入：卡链接handle io编号，从1开始
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadHomeState(SMCHANDLE handle, uint8 iaxis, uint8* pIoState);


/*************************************************************
说明：读急停输入状态
输入：卡链接handle
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadEMGState(SMCHANDLE handle, uint8* pIoState);
/*************************************************************
说明：读手轮AB输入状态, 6200的手轮为9 10，与轴号无关 
输入：卡链接handle
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadHandWheelStates(SMCHANDLE handle, uint8 iaxis, uint8* pIoAState, uint8* pIoBState);

/*************************************************************
说明：读限位状态
输入：卡链接handle
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadElStates(SMCHANDLE handle, uint8 iaxis, uint8* pElDecState, uint8* pElPlusState);


/*************************************************************
说明：读减速信号输入状态
输入：卡链接handle io编号，从1开始
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadSdStates(SMCHANDLE handle, uint8 iaxis, uint8* pIoState);

/*************************************************************
说明：读到位信号输入状态
输入：卡链接handle io编号，从1开始
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadInpStates(SMCHANDLE handle, uint8 iaxis, uint8* pIoState);

/*************************************************************
说明：读轴所有输入状态
输入：卡链接handle 轴号，当0XFF的时候，表示读取所有的轴，
输出：0-有效， 1- 无效
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadAxisStates(SMCHANDLE handle, uint8 iaxis, struct_AxisStates* pAxisState);
/*************************************************************
说明：写PWM占空比
输入：卡链接handle 通道:1/2
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWritePwmDuty(SMCHANDLE handle, uint8 ichannel, float fDuty);
/*************************************************************
说明：写PWM频率
输入：卡链接handle 通道:1/2
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWritePwmFreqency(SMCHANDLE handle, uint8 ichannel, float fFre);

/*************************************************************
说明：写DA输出电压
输入：卡链接handle 通道:1/2
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCWriteDaOut(SMCHANDLE handle, uint8 ichannel, float fLevel);

/*************************************************************
说明：PWM占空比
输入：卡链接handle 通道:1/2
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadPwmDuty(SMCHANDLE handle, uint8 ichannel, float* fDuty);

/*************************************************************
说明：PWM频率
输入：卡链接handle 通道:1/2
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadPwmFreqency(SMCHANDLE handle, uint8 ichannel, float* fFre);

/*************************************************************
说明：DA输出电压
输入：卡链接handle 通道:1/2
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCReadDaOut(SMCHANDLE handle, uint8 ichannel, float* fLevel);


/*************************************************************
说明：客户编号, 这个函数只对部分客户开放
输入：卡链接handle
输出：状态
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetClientId(SMCHANDLE handle,uint16 *pId);

/*************************************************************
说明：软件产品类型
输入：卡链接handle
输出：状态
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetSoftwareId(SMCHANDLE handle,uint16 *pId);


/*************************************************************
说明：硬件编号
输入：卡链接handle
输出：状态
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetHardwareId(SMCHANDLE handle,uint16 *pId);


/*************************************************************
说明：软件版本号，用日期标识
输入：卡链接handle
输出：状态
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetSoftwareVersion(SMCHANDLE handle,uint32 *pVersion);

/*************************************************************
说明：上传密码文件
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpPasswordFile(SMCHANDLE handle, const char* pfilename);

/*************************************************************
说明：上传密码文件
输入：卡链接handle 内存buff 返回实际的文件长度
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpPasswordFileToMem(SMCHANDLE handle, char* pbuffer, uint32 buffsize, uint32* puifilesize);

/*************************************************************
说明：下载密码文件
输入：卡链接handle 文件名
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownPasswordFile(SMCHANDLE handle, const char* pfilename);


/*************************************************************
说明：下载密码文件, 文本文件的长度用strlen 即可
输入：卡链接handle buff 
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownMemPasswordFile(SMCHANDLE handle, const char* pbuffer, uint32 buffsize);


/*************************************************************
说明：输入密码
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCEnterSetPassword(SMCHANDLE handle, uint32 uipassword);

/*************************************************************
说明：输入密码
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCEnterEditPassword(SMCHANDLE handle, uint32 uipassword);


/*************************************************************
说明：输入密码
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCEnterSuperPassword(SMCHANDLE handle, uint32 uipassword);

/*************************************************************
说明：输入密码
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCEnterTimePassword(SMCHANDLE handle, uint32 uipassword);


/*************************************************************
说明：清除已经输入的密码, 必须再次输入密码才能进行相应操作
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCClearEnteredPassword(SMCHANDLE handle);

/*************************************************************
说明：修改密码
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCModifySetPassword(SMCHANDLE handle, uint32 uipassword);

/*************************************************************
说明：修改密码
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCModifyEditPassword(SMCHANDLE handle, uint32 uipassword);

/*************************************************************
说明：修改密码
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCModifySuperPassword(SMCHANDLE handle, uint32 uipassword);
/*************************************************************
说明：获取用户试用情况
输入：卡链接handle 密码
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetTrialCondition(SMCHANDLE handle, uint32* pRunHours, uint16* pbifTimeLocked, uint16* pAlreadyEnterdTimePasswordNum);


#if 0
/********************  这些函数不对外开放 ***********************/
#endif


/*************************************************************
说明：固件下载
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownFirmWare(SMCHANDLE handle, const char* pfirmwarefilename);

/*************************************************************
说明：读取控制器ID
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetControllerID(SMCHANDLE handle, uint32 *pid);

/*************************************************************
说明：设置控制器ID
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetControllerID(SMCHANDLE handle, uint32 id);
/*************************************************************
说明：格式化
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCLowFormatNand(SMCHANDLE handle);
/*************************************************************
说明：软复位
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCResetController(SMCHANDLE handle);

/*************************************************************
说明：硬件测试
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCStartHardwareTest(SMCHANDLE handle);

/*************************************************************
说明：读取控制器ID
输入：卡链接handle mac地址，字符串方式
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetMac(SMCHANDLE handle, char *smac);

/*************************************************************
说明：设置控制器ID
输入：卡链接handle
输出： mac地址，字符串方式
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetMac(SMCHANDLE handle, char *smac);

/*************************************************************
说明：查找控制器上的文件， 文件名为空表示文件不不存在
输入：卡链接handle 控制器上文件名，带扩展
输出： 文件名 文件大小
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCFindFirstFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);
/*************************************************************
说明：查找控制器上的文件， 文件名为空表示文件不不存在
输入：卡链接handle 控制器上文件名，带扩展
输出： 是否存在 文件大小
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCFindNextFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);

/*************************************************************
说明：下载文件
输入：卡链接handle 文件名
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownFile(SMCHANDLE handle, const char* pfilename, const char* pfilenameinControl);

/*************************************************************
说明：下载文件, 文本文件的长度用strlen 即可
输入：卡链接handle buff 
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDownMemFile(SMCHANDLE handle, const char* pbuffer, uint32 buffsize, const char* pfilenameinControl);

/*************************************************************
说明：上传
输入：卡链接handle 内存buff
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpFile(SMCHANDLE handle, const char* pfilename, const char* pfilenameinControl);

/*************************************************************
说明：上传
输入：卡链接handle 内存buff 返回实际的文件长度
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCUpFileToMem(SMCHANDLE handle, char* pbuffer, uint32 buffsize, const char* pfilenameinControl, uint32* puifilesize);

/*************************************************************
说明：删除控制器上的文件
输入：卡链接handle
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCDeleteFile(SMCHANDLE handle, const char* pfilenameinControl);

/*************************************************************
说明：测试使用
输入：
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCTestSoftware(SMCHANDLE handle);


/********************** 上面函数不对外开放 ***************************/


/*************************************************************
说明：modbus寄存器操作
输入：卡链接handle 寄存器地址
输出：
返回值：错误码
*************************************************************/
SMC6200API  uint32 __stdcall SMCModbus_Set0x(SMCHANDLE handle, uint16 start, uint16 inum, uint8* pdata);
SMC6200API  uint32 __stdcall SMCModbus_Get0x(SMCHANDLE handle, uint16 start, uint16 inum, uint8* pdata);
SMC6200API  uint32 __stdcall SMCModbus_Get4x(SMCHANDLE handle, uint16 start, uint16 inum, uint16* pdata);
SMC6200API  uint32 __stdcall SMCModbus_Set4x(SMCHANDLE handle, uint16 start, uint16 inum, uint16* pdata);


/*************************************************************
说明：把错误码转成描述字符串
输入：应答的消息
输出：
返回值：错误码
*************************************************************/
char* __stdcall SMCGetErrcodeDescription(int32 ierrcode);
/*************************************************************
说明：检查程序语法
输入：错误字符串缓存，至少1024字节
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCCheckProgramSyntax(const char *sin, char *sError);

SMC6200API  int32 __stdcall SMC_MultiLine(SMCHANDLE handle,uint8 itotalaxis, uint8* piaxisList, uint16 uiSectes, double* DistanceList, double* dspeedList, uint8 bIfAbs);


/*ADD*/
/*************************************************************
说明： 设置S曲线比例
输入：axis 轴号
	   para 曲线比例
输出：无
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCLineScureSet(SMCHANDLE handle,uint8 axis,double para);





/*************************************************************
说明：设置工件零点
输入：卡链接handle 轴号0-3 坐标
输出：
返回值：错误码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetWorkOriginPosition(SMCHANDLE handle, uint8 iaxis, double dposition);


/*************************************************************
功能：设置/读取软件限位的使能, 限位数值, 响应动作
参数：axis 指定轴号
	  ON_OFF 软限位使能， 0 –禁止； 1 –使能
      SL_action 限位动作， 0 –急停， 1 –减速停
      N_limit 负限位值
      P_limit 正限位值
返回值：错误代码
*************************************************************/
SMC6200API  int32 __stdcall SMCConfigSoftlimit(SMCHANDLE handle, uint8 axis, uint8 ON_OFF,uint8 SL_action,float N_limit,float Plimit);


/*************************************************************
功能：设置/读取软件限位的使能, 限位数值, 响应动作
参数：axis 指定轴号
	  ON_OFF 软限位使能， 0 –禁止； 1 –使能
      SL_action 限位动作， 0 –急停， 1 –减速停
      N_limit 负限位值
      P_limit 正限位值
返回值：错误代码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetConfigSoftlimit(SMCHANDLE handle, uint8 axis, uint8 *ON_OFF,uint8 *SL_action,float *N_limit,float *Plimit);
/*************************************************************
功能：设置/读取间隙补偿值
参数：axis 指定轴号
backlash 间隙补偿值， 单位：脉冲
返回值：错误代码
*************************************************************/
SMC6200API  int32 __stdcall SMCSetBackLash(SMCHANDLE handle, uint8 axis, int32 lash );
/*************************************************************
功能：设置/读取间隙补偿值
参数：axis 指定轴号
backlash 间隙补偿值， 单位：脉冲
返回值：错误代码
*************************************************************/
SMC6200API  int32 __stdcall SMCGetBackLash(SMCHANDLE handle, uint8 axis, int32 *lash );


/**************************************************************
功能：多种不同的回原点模式，实现精确定位到原点的方法，通过调用此函数便可以选择其中一种模式。
参数：axis：轴号；
home_dir 回零方向，1：正方向，2：负方向
vel 回零速度
mode 回原点的信号模式
1 – 一次回零
2 – 二次回零
3 – 一次回零加回找
返回值：错误代码
**********************************************************************/
SMC6200API  int32 __stdcall SMCConfigHomeMode(SMCHANDLE handle, uint8 axis,uint8 home_dir,double vel,uint8 mode);
#ifdef  __cplusplus
}
#endif

#endif
