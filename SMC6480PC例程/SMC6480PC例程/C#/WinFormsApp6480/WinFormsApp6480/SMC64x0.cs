using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace csSMC6X
{
    //
    // 连接类型, 6200可以用串口与网口
    enum SMC6X_CONNECTION_TYPE
    {
        SMC6X_CONNECTION_COM = 1,
        SMC6X_CONNECTION_ETH = 2,
        SMC6X_CONNECTION_USB = 3,
        SMC6X_CONNECTION_PCI = 4,
    };

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


    //[System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    class SMC6X
    {
        /*********************************************************
        函数声明
        **********************************************************/

        /*************************************************************
        说明：与控制器建立链接
        输入：无
        输出：卡链接phandle
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpen")]//, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
            public static extern Int32 SMCOpen(SMC6X_CONNECTION_TYPE type, string pconnectstring , ref IntPtr phandle);
            //Int32 SMCOpen(SMC6X_CONNECTION_TYPE type, ref Byte pconnectstring ,ref IntPtr phandle);

        /*************************************************************
        说明：与控制器建立链接
        输入：无
        输出：卡链接phandle
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpenCom")]
            public static extern Int32 SMCOpenCom(Int32 comid, ref IntPtr phandle);
            //Int32 SMCOpenCom(uint comid, ref IntPtr phandle);

        /*************************************************************
        说明：与控制器建立链接
        输入：IP地址，字符串的方式输入
        输出：卡链接phandle
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpenEth")]
            public static extern Int32 SMCOpenEth(string ipaddr, ref IntPtr phandle);
            //Int32 __stdcall SMCOpenEth(ref Byte ipaddr, ref IntPtr phandle);

        /*************************************************************
        说明：与控制器建立链接
        输入：IP地址，32位数的IP地址输入, 注意字节顺序
        输出：卡链接phandle
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCOpenEth2")]
            public static extern Int32 SMCOpenEth2(Int32 straddr, ref IntPtr phandle);
            //Int32 __stdcall SMCOpenEth2(struct in_addr straddr, ref IntPtr phandle);

        /*************************************************************
        说明：关闭控制器链接
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCClose")]
            public static extern Int32 SMCClose(IntPtr phandle);
            //Int32 __stdcall SMCClose(IntPtr  phandle);


        /*************************************************************
        说明：命令的延时等待时间
        输入：卡链接phandle 毫秒时间
        输出：
        返回值：错误码
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCSetTimeOut")]
            public static extern Int32 SMCSetTimeOut(IntPtr phandle, Int32 timems);
        //[DllImport("smc6x.dll", EntryPoint = "")] Int32 __stdcall SMCSetTimeOut(IntPtr  phandle, Int32 timems);

        /*************************************************************
        说明：命令的延时等待时间
        输入：卡链接phandle 
        输出：毫秒时间
        返回值：错误码
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetTimeOut")]
            public static extern Int32 SMCGetTimeOut(IntPtr phandle, ref Int32 ptimems);
        //[DllImport("smc6x.dll", EntryPoint = "")] Int32 __stdcall SMCGetTimeOut(IntPtr  phandle, ref Int32 ptimems);

        /*************************************************************
        说明：读取长时间命令的进度
        输入：卡链接phandle 
        输出：
        返回值：进度， 浮点， 
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetProgress")]
         public static extern float SMCGetProgress(IntPtr phandle);
       // float  __stdcall SMCGetProgress(IntPtr  phandle);


        /**********************************************
            command 函数列表
        *******************************************/


        /*************************************************************
        说明：//读取系统状态
        输入：卡链接phandle
        输出：状态
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetState")]
         public static extern float SMCGetState(IntPtr phandle,ref Byte pstate);
        //[DllImport("smc6x.dll", EntryPoint = "")] Int32 __stdcall SMCGetState(IntPtr phandle,ref Byte  pstate);

        /*************************************************************
        说明：//读取链接控制器的轴数
        输入：卡链接phandle
        输出：
        返回值：轴数，出错0
        *************************************************************/
         [DllImport("smc6x.dll", EntryPoint = "SMCGetAxises")]
         public static extern Byte SMCGetAxises(IntPtr phandle);
         //Byte __stdcall SMCGetAxises(SMCHANDLE handle);

        /*************************************************************
        说明：下载程序文件 下载前会编译一次
        输入：卡链接phandle 文件名
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownProgram")]
         public static extern Int32 SMCDownProgram(IntPtr phandle, string pfilename, string pfilenameinControl);

        /*************************************************************
        说明：下载程序文件 下载前会编译一次
        输入：卡链接phandle buff 控制器上文件的名字
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemProgram")]
         public static extern Int32 SMCDownMemProgram(IntPtr phandle, string pbuffer, Int32 buffsize, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDownProgram(SMCHANDLE handle, string pfilename, string pfilenameinControl);

        /*************************************************************
        说明：下载程序文件 到临时文件中
        输入：卡链接phandle buff 控制器上文件的名字
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownProgramToTemp")]
         public static extern Int32 SMCDownProgramToTemp(IntPtr phandle, string pfilename);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDownProgramToTemp(SMCHANDLE handle, string pfilename);

        /*************************************************************
        说明：下载程序文件 到临时文件中
        输入：卡链接phandle buff 控制器上文件的名字
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemProgramToTemp")]
         public static extern Int32 SMCDownMemProgramToTemp(IntPtr phandle, string pbuffer, Int32 buffsize);


        /*************************************************************
        说明：运行
        输入：卡链接phandle 文件名， 当为NULL的时候运行缺省文件
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCRunProgramFile")]
        public static extern Int32 SMCRunProgramFile(IntPtr phandle, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCRunProgramFile(SMCHANDLE handle, string pfilenameinControl);


        /*************************************************************
        说明：下载到ram中运行
        输入：卡链接phandle 文件名
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownProgramToRamAndRun")]
        public static extern  Int32 SMCDownProgramToRamAndRun(IntPtr phandle, string pfilename);

        /*************************************************************
        说明：下载到ram中运行
        输入：卡链接phandle 内存buff
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemProgramToRamAndRun")]
        public static extern Int32 SMCDownMemProgramToRamAndRun(IntPtr phandle, string pbuffer,Int32 buffsize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDownMemProgramToRamAndRun(SMCHANDLE handle, string pbuffer, uint32 buffsize);


        /*************************************************************
        说明：上传程序文件
        输入：卡链接phandle 内存buff
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpProgram")]
        public static extern Int32 SMCUpProgram(IntPtr phandle, string pfilename, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCUpProgram(SMCHANDLE handle, string pfilename, string pfilenameinControl);

        /*************************************************************
        说明：上传程序文件
        输入：卡链接phandle 内存buff
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpProgramToMem")]
        public static extern Int32 SMCUpProgramToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize, string pfilenameinControl, ref Int32 puifilesize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCUpProgramToMem(SMCHANDLE handle, char* pbuffer, uint32 buffsize, char* pfilenameinControl, uint32* puifilesize);


        /*************************************************************
        说明：暂停
        输入：卡链接phandle 文件名， 当为NULL的时候运行缺省文件
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPause")]
         public static extern Int32 SMCPause(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCPause(SMCHANDLE handle);

        /*************************************************************
        说明：停止
        输入：卡链接phandle 文件名， 当为NULL的时候运行缺省文件
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCStop")]
        public static extern Int32 SMCStop(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCStop(SMCHANDLE handle);

        /*************************************************************
        说明：运行临时文件
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCRunTempFile")]
        public static extern  Int32 SMCRunTempFile(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCRunTempFile(SMCHANDLE handle);

        /*************************************************************
        说明：读取剩余空间
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckRemainProgramSpace")]
        public static extern Int32 SMCCheckRemainProgramSpace(IntPtr phandle, ref Int32 pRemainSpaceInKB);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCCheckRemainProgramSpace(SMCHANDLE handle, uint32 * pRemainSpaceInKB);


        /*************************************************************
        说明：读取程序停止原因
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckProgramStopReason")]
        public static extern Int32 SMCCheckProgramStopReason(IntPtr phandle, ref Int32 pStopReason);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCCheckProgramStopReason(SMCHANDLE handle, uint32 * pStopReason);

        /*************************************************************
        说明：读取程序当前行
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurRunningLine")]
        public static extern Int32 SMCGetCurRunningLine(IntPtr phandle, ref Int32 pLineNum);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetCurRunningLine(SMCHANDLE handle, uint32 * pLineNum);


        /*************************************************************
        说明：设置单步运行，这个实时修改状态，重启后丢失
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetStepRun")]
        public static extern Int32 SMCSetStepRun(IntPtr phandle, Byte bifStep);
       // [DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetStepRun(SMCHANDLE handle, Byte bifStep);


        /*************************************************************
        说明：设置空走，这个实时修改状态，重启后丢失
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetRunNoIO")]
        public static extern Int32 SMCSetRunNoIO(IntPtr phandle, Byte bifVainRun);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetRunNoIO(SMCHANDLE handle, Byte bifVainRun);

        /*************************************************************
        说明：读取设置
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetRunningOption")]
        public static extern Int32 SMCGetRunningOption(IntPtr phandle, ref Byte bifStep, ref Byte bifVainRun);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetRunningOption(SMCHANDLE handle, ref Byte bifStep, ref Byte bifVainRun);



        /*************************************************************
        说明：继续运行
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCContinueRun")]
        public static extern Int32 SMCContinueRun(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCContinueRun(SMCHANDLE handle);


        /*************************************************************
        说明：检查文件是否存在
        输入：卡链接phandle 控制器上文件名，不带扩展
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckProgramFile")]
        public static extern Int32 SMCCheckProgramFile(IntPtr phandle, string pfilenameinControl, ref Byte pbIfExist, ref Int32 pFileSize);
        //[DllImport("smc6x.dll", EntryPoint = "")]
        //public static extern Int32 SMCCheckProgramFile(IntPtr phandle, string pfilenameinControl, ref Byte pbIfExist, ref Int32 pFileSize);


        /*************************************************************
        说明：查找控制器上的文件， 文件名为空表示文件不不存在
        输入：卡链接phandle 控制器上文件名，不带扩展
        输出： 是否存在 文件大小
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCFindFirstProgramFile")]
        public static extern Int32 SMCFindFirstProgramFile(IntPtr phandle, ref Byte pfilenameinControl, ref Int32 pFileSize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCFindFirstProgramFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);


        /*************************************************************
        说明：查找控制器上的文件， 文件名为空表示文件不不存在
        输入：卡链接phandle 控制器上文件名，不带扩展
        输出： 是否存在 文件大小
        返回值：错误码
        *************************************************************/
       [DllImport("smc6x.dll", EntryPoint = "SMCFindNextProgramFile")]
        public static extern  Int32 SMCFindNextProgramFile(IntPtr phandle, ref Byte pfilenameinControl, ref Int32 pFileSize);

        /*************************************************************
        说明：查找控制器上的当前文件
        输入：卡链接phandle 控制器上文件名，不带扩展
        输出： 是否存在 文件大小(暂时不支持)
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurProgramFile")]
        public static extern  Int32 SMCGetCurProgramFile(IntPtr phandle, ref Byte pfilenameinControl, ref Int32 pFileSize);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetCurProgramFile(SMCHANDLE handle, char* pfilenameinControl, uint32 *pFileSize);


        /*************************************************************
        说明：删除控制器上的文件
        输入：卡链接phandle 控制器上文件名，不带扩展
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDeleteProgramFile")]
        public static extern Int32 SMCDeleteProgramFile(IntPtr phandle, string pfilenameinControl);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCDeleteProgramFile(SMCHANDLE handle, string pfilenameinControl);

        /*************************************************************
        说明：删除控制器上的文件
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCRemoveAllProgramFiles")]
        public static extern  Int32 SMCRemoveAllProgramFiles(IntPtr phandle);
   

        /***********************  设置部分  ************************/


        /*************************************************************
        说明：通用的字符串接口
        输入：卡链接phandle 发送字符串，接收字符串， 接收字符串长度, 当不想要应答时，把uiResponseLength = 0
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCommand")]
        public static extern  Int32 SMCCommand(IntPtr phandle, string pszCommand, ref Byte psResponse, Int32 uiResponseLength);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCCommand(SMCHANDLE handle, string pszCommand, char* psResponse, uint32 uiResponseLength);

        /*************************************************************
        说明：当前设置存盘
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCBurnSetting")]
        public static extern  Int32 SMCBurnSetting(IntPtr phandle);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCBurnSetting(SMCHANDLE handle);


        /*************************************************************
        说明：下载设置文件
        输入：卡链接phandle 文件名
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownSetting")]
        public static extern  Int32 SMCDownSetting(IntPtr phandle, string pfilename);

        /*************************************************************
        说明：下载设置文件
        输入：卡链接phandle buff 
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemSetting")]
        public static extern  Int32 SMCDownMemSetting(IntPtr phandle, string pbuffer, Int32 buffsize);

        /*************************************************************
        说明：上传设置
        输入：卡链接phandle 内存buff
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpSetting")]
        public static extern  Int32 SMCUpSetting(IntPtr phandle, string pfilename);
        /*************************************************************
        说明：上传设置
        输入：卡链接phandle 内存buff 返回实际的文件长度
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpSettingToMem")]
        public static extern  Int32 SMCUpSettingToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize,  ref Int32 puifilesize);


        /*************************************************************
        说明：下载设置文件
        输入：卡链接phandle 文件名
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownDefaultSetting")]
        public static extern  Int32 SMCDownDefaultSetting(IntPtr phandle, string pfilename);
        /*************************************************************
        说明：下载设置文件, 文本文件的长度用strlen 即可
        输入：卡链接phandle buff 
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemDefaultSetting")]
        public static extern  Int32 SMCDownMemDefaultSetting(IntPtr phandle, string pbuffer, Int32 buffsize);

        /*************************************************************
        说明：上传设置
        输入：卡链接phandle 内存buff
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpDefaultSetting")]
        public static extern  Int32 SMCUpDefaultSetting(IntPtr phandle, string pfilename);

        /*************************************************************
        说明：上传设置
        输入：卡链接phandle 内存buff
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpDefaultSettingToMem")]
        public static extern  Int32 SMCUpDefaultSettingToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize, ref Int32 puifilesize);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetIpAddr")]
        public static extern  Int32 SMCSetIpAddr(IntPtr phandle, string sIpAddr, string sGateAddr, string sMask, Byte bifdhcp);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetIpAddr(SMCHANDLE handle, char* sIpAddr, char* sGateAddr, char* sMask, ref Byte  pbifdhcp);


        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetIpAddr")]
        public static extern  Int32 SMCGetIpAddr(IntPtr phandle, ref Byte sIpAddr, ref Byte sGateAddr, ref Byte sMask, ref Byte pbifdhcp);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetIpAddr(SMCHANDLE handle, char* sIpAddr, char* sGateAddr, char* sMask, ref Byte  pbifdhcp);

        /*************************************************************
        说明：读取当前控制器的IP地址, 注意:当设置dhcp以后，设置的IP与实际的不一致。
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurIpAddr")]
        public static extern  Int32 SMCGetCurIpAddr(IntPtr phandle, ref Byte sIpAddr);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetZeroSpeed")]
        public static extern  Int32 SMCSetZeroSpeed(IntPtr phandle, Byte iaxis, Int32 uiSpeed);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetZeroSpeed(SMCHANDLE handle, Byte iaxis, uint32 uiSpeed);


        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetZeroSpeed")]
        public static extern  Int32 SMCGetZeroSpeed(IntPtr phandle, Byte iaxis, ref Int32 puiSpeed);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCGetZeroSpeed(SMCHANDLE handle, Byte iaxis, uint32* puiSpeed);


        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateSpeed")]
        public static extern  Int32 SMCSetLocateSpeed(IntPtr phandle, Byte iaxis, Int32 uiSpeed);
        //[DllImport("smc6x.dll", EntryPoint = "")] int32 __stdcall SMCSetLocateSpeed(SMCHANDLE handle, Byte iaxis, uint32 uiSpeed);


        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateSpeed")]
        public static extern Int32 SMCGetLocateSpeed(IntPtr phandle, Byte iaxis, ref Int32 puiSpeed);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateStartSpeed")]
        public static extern Int32 SMCSetLocateStartSpeed(IntPtr phandle, Byte iaxis, Int32 uiSpeed);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateStartSpeed")]
        public static extern Int32 SMCGetLocateStartSpeed(IntPtr phandle, Byte iaxis, ref Int32 puiSpeed);


        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateAcceleration")]
        public static extern Int32 SMCSetLocateAcceleration(IntPtr phandle, Byte iaxis, Int32 uiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateAcceleration")]
        public static extern  Int32 SMCGetLocateAcceleration(IntPtr phandle, Byte iaxis, ref Int32 puiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetLocateDeceleration")]
        public static extern Int32 SMCSetLocateDeceleration(IntPtr phandle, Byte iaxis, Int32 uiValue);
        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetLocateDeceleration")]
        public static extern Int32 SMCGetLocateDeceleration(IntPtr phandle, Byte iaxis, ref Int32 puiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetUnitPulses")]
        public static extern Int32 SMCSetUnitPulses(IntPtr phandle, Byte iaxis, Int32 uiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetUnitPulses")]
        public static extern  Int32 SMCGetUnitPulses(IntPtr phandle, Byte iaxis, ref Int32 puiValue);


        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectStartSpeed")]
        public static extern Int32 SMCSetVectStartSpeed(IntPtr phandle, Int32 uiValue);
        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectStartSpeed")]
        public static extern Int32 SMCGetVectStartSpeed(IntPtr phandle, ref Int32 puiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectSpeed")]
        public static extern  Int32 SMCSetVectSpeed(IntPtr phandle, Int32 uiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectSpeed")]
        public static extern  Int32 SMCGetVectSpeed(IntPtr phandle, ref Int32 puiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectAcceleration")]
        public static extern Int32 SMCSetVectAcceleration(IntPtr phandle, Int32 uiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectAcceleration")]
        public static extern Int32 SMCGetVectAcceleration(IntPtr phandle, ref Int32 puiValue);


        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetVectDeceleration")]
        public static extern Int32 SMCSetVectDeceleration(IntPtr phandle, Int32 uiValue);

        /*************************************************************
        说明：参数函数
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectDeceleration")]
        public static extern Int32 SMCGetVectDeceleration(IntPtr phandle, ref Int32 puiValue);



        /***********************  运动部分  ************************/
 
        /*************************************************************
        说明：
        输入：卡链接phandle 轴号， 长度， 是否绝对移动
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPMove")]
        public static extern Int32 SMCPMove(IntPtr phandle, Byte iaxis, double dlength, Byte bIfAbs);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号， 长度， 是否绝对移动
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPMovePluses")]
        public static extern Int32 SMCPMovePluses(IntPtr phandle, Byte iaxis, Int32 ilength, Byte bIfAbs);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号， 方向
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVMove")]
        public static extern Int32 SMCVMove(IntPtr phandle, Byte iaxis, Byte bIfPositiveDir);


        /*************************************************************
        说明：
        输入：卡链接phandle 轴号， 方向
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCPMoveList")]
        public static extern Int32 SMCPMoveList(IntPtr phandle,Byte itotalaxises,  ref Byte puilineaxislist, Int32 uisteps, ref double pDistanceList, Byte bIfAbs);



        /*************************************************************
        说明：
        输入：卡链接phandle 轴号， 方向
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckDown")]
        public static extern Int32 SMCCheckDown(IntPtr phandle,Byte iaxis,  ref Byte pbIfDown);

        /*************************************************************
        说明：回零，回零模式通过参数指定
        输入：卡链接phandle 轴号， 方向
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCHomeMove")]
        public static extern Int32 SMCHomeMove(IntPtr phandle,Byte iaxis);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCIfHomeMoveing")]
        public static extern Int32 SMCIfHomeMoveing(IntPtr phandle,Byte iaxis, ref Byte pbIfHoming);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDecelStop")]
        public static extern Int32 SMCDecelStop(IntPtr phandle,Byte iaxis);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCImdStop")]
        public static extern Int32 SMCImdStop(IntPtr phandle,Byte iaxis);


        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEmgStop")]
        public static extern Int32 SMCEmgStop(IntPtr phandle);

        /*************************************************************
        说明：变速度
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCChangeSpeed")]
        public static extern Int32 SMCChangeSpeed(IntPtr phandle,Byte iaxis, double dspeed);


        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：坐标
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetPosition")]
        public static extern Int32 SMCGetPosition(IntPtr phandle,Byte iaxis, ref double pposition);


        /*************************************************************
        说明： 读取当前的工件坐标
        输入：卡链接phandle 轴号
        输出：坐标
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetWorkPosition")]
        public static extern Int32 SMCGetWorkPosition(IntPtr phandle,Byte iaxis, ref double pposition);

        /*************************************************************
        说明： 读取机械坐标，脉冲方式
        输入：卡链接phandle 轴号
        输出：坐标
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetPositionPulses")]
        public static extern Int32 SMCGetPositionPulses(IntPtr phandle,Byte iaxis, ref Int32 pposition);

        /*************************************************************
        说明： 读取工件零点
        输入：卡链接phandle 轴号
        输出：坐标
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetWorkOriginPosition")]
        public static extern Int32 SMCGetWorkOriginPosition(IntPtr phandle, Byte iaxis, ref double pposition);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号 坐标
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetPosition")]
        public static extern Int32 SMCSetPosition(IntPtr phandle,Byte iaxis, double dposition);
        /*************************************************************
        说明：
        输入：卡链接phandle 轴号 坐标
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetPositionPulses")]
        public static extern Int32 SMCSetPositionPulses(IntPtr phandle,Byte iaxis, Int32 iposition);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWaitDown")]
        public static extern Int32 SMCWaitDown(IntPtr phandle,Byte iaxis);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWaitPoint")]
        public static extern Int32 SMCWaitPoint(IntPtr phandle,Byte iaxis, double dpos);

        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCHandWheelSet")]
        public static extern Int32 SMCHandWheelSet(IntPtr phandle,Byte iaxis, Int32 imulti, Byte bifDirReverse);
        /*************************************************************
        说明：
        输入：卡链接phandle 轴号
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCHandWheelMove")]
        public static extern Int32 SMCHandWheelMove(IntPtr phandle,Byte iaxis, Byte bifenable);


        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveStart")]
        public static extern Int32 SMCVectMoveStart(IntPtr phandle);

        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveEnd")]
        public static extern Int32 SMCVectMoveEnd(IntPtr phandle);


        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectMoveState")]
        public static extern Int32 SMCGetVectMoveState(IntPtr phandle, ref Byte pState);

        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/

        [DllImport("smc6x.dll", EntryPoint = "SMCGetVectMoveRemainSpace")]
        public static extern Int32 SMCGetVectMoveRemainSpace(IntPtr phandle, ref Int32 pSpace);

        /*************************************************************
        说明：插补，会修改速度设置
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveLine1")]
        public static extern Int32 SMCVectMoveLine1(IntPtr phandle, Byte iaxis, double Distance, double dspeed, Byte bIfAbs);
        /*************************************************************
        说明：插补，会修改速度设置
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveLine2")]
        public static extern Int32 SMCVectMoveLine2(IntPtr phandle, Byte iaxis1, double Distance1, Byte iaxis2, double Distance2, double dspeed, Byte bIfAbs);

        /*************************************************************
        说明：插补，不会修改速度设置
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveLineN")]
        public static extern Int32 SMCVectMoveLineN(IntPtr phandle, Byte itotalaxis, ref Byte piaxisList, ref double DistanceList, double dspeed, Byte bIfAbs);

        /*************************************************************
        说明：插补，会修改速度设置
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveMultiLine2")]
        public static extern Int32 SMCVectMoveMultiLine2(IntPtr phandle, Byte iaxis1, Byte iaxis2, Int32 uiSectes, ref double DistanceList, ref double dspeedList, Byte bIfAbs);

        /*************************************************************
        说明：插补，不会修改速度设置
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveMultiLineN")] 
        public static extern Int32 SMCVectMoveMultiLineN(IntPtr phandle, Byte itotalaxis, ref Byte piaxisList, Int32 uiSectes,ref double DistanceList, ref double dspeedList, Byte bIfAbs);

        /*************************************************************
        说明：插补，会修改速度设置
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveArc")] 
        public static extern Int32 SMCVectMoveArc(IntPtr phandle, Byte iaxis1, Byte iaxis2, double Distance1, double Distance2, double Center1, double Center2, Byte bIfAnticlockwise, double dspeed, Byte bIfAbs);


        /*************************************************************
        说明：减速点加入
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveSetSpeedLimition")] 
        public static extern Int32 SMCVectMoveSetSpeedLimition(IntPtr phandle, double dspeed);


        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWaitVectLength")] 
        public static extern Int32 SMCWaitVectLength(IntPtr phandle, double vectlength);

        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurRunVectLength")] 
        public static extern Int32 SMCGetCurRunVectLength(IntPtr phandle, ref double pvectlength);
        /*************************************************************
        说明：
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetCurSpeed")] 
        public static extern Int32 SMCGetCurSpeed(IntPtr phandle, Byte iaxis, ref double pspeed);

        /*************************************************************
        说明： 运行暂停, 插补暂停后仍然可以加入小段
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMovePause")]
        public static extern Int32 SMCVectMovePause(IntPtr phandle);

        /*************************************************************
        说明： 插补运行停止
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCVectMoveStop")] 
        public static extern Int32 SMCVectMoveStop(IntPtr phandle);


        /*************************************************************
        说明：暂停; 这个函数功能暂不支持
        输入：卡链接phandle
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCAxisPause")] 
        public static extern Int32 SMCAxisPause(IntPtr phandle, Byte iaxis);

        /***********************  IO等接口部分  ************************/

        /*************************************************************
        说明：点亮LED，或者灭掉
        输入：卡链接phandle led编号，从1开始
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteLed")] 
        public static extern Int32 SMCWriteLed(IntPtr phandle, Int32 iLedNum, Byte bifLighten);


        /*************************************************************
        说明：写输出口
        输入：卡链接phandle io编号，从1开始 0-低电平， 1- 高电平
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteOutBit")] 
        public static extern Int32 SMCWriteOutBit(IntPtr phandle, Int32 ioNum, Byte IoState);

        /*************************************************************
        说明：读输入口
        输入：卡链接phandle io编号，从1开始
        输出：0-低电平， 1- 高电平
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadInBit")] 
        public static extern Int32 SMCReadInBit(IntPtr phandle, Int32 ioNum, ref Byte pIoState);

        /*************************************************************
        说明：读输出口
        输入：卡链接phandle io编号，从1开始
        输出：0-低电平， 1- 高电平
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadOutBit")] 
        public static extern Int32 SMCReadOutBit(IntPtr phandle, Int32 ioNum, ref Byte pIoState);

        /*************************************************************
        说明：写全部输出口
        输入：卡链接phandle 
              IoMask: 1的位要修改，可以通过这个参数修改指定几个IO
              IoState:  0-低电平， 1- 高电平;  0-31位 代表 1-32IO
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteOutPort")] 
        public static extern Int32 SMCWriteOutPort(IntPtr phandle, Int32 IoMask, Int32 IoState);

        /*************************************************************
        说明：读全部输入口
        输入：卡链接phandle 
        输出：0-低电平， 1- 高电平
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadInPort")]
        public static extern Int32 SMCReadInPort(IntPtr phandle, ref Int32 pIoState);

        /*************************************************************
        说明：读全部输出口
        输入：卡链接phandle 
        输出：0-低电平， 1- 高电平
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadOutPort")] 
        public static extern Int32 SMCReadOutPort(IntPtr phandle, ref Int32 pIoState);


        /*************************************************************
        说明：读伺服告警输入状态 6200没有
        输入：卡链接phandle io编号，从1开始
        输出：0-有效， 1- 无效
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadAlarmState")] 
        public static extern Int32 SMCReadAlarmState(IntPtr phandle, Byte iaxis, ref Byte pIoState);

        /*************************************************************
        说明：读原点输入状态
        输入：卡链接phandle io编号，从1开始
        输出：0-有效， 1- 无效
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadHomeState")] 
        public static extern Int32 SMCReadHomeState(IntPtr phandle, Byte iaxis, ref Byte pIoState);


        /*************************************************************
        说明：读急停输入状态
        输入：卡链接phandle
        输出：0-有效， 1- 无效
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadEMGState")]
        public static extern Int32 SMCReadEMGState(IntPtr phandle, ref Byte pIoState);
        /*************************************************************
        说明：读手轮AB输入状态, 6200的手轮为9 10，与轴号无关 
        输入：卡链接phandle
        输出：0-有效， 1- 无效
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadHandWheelStates")]
        public static extern Int32 SMCReadHandWheelStates(IntPtr phandle, Byte iaxis, ref Byte pIoAState, ref Byte pIoBState);

        /*************************************************************
        说明：读限位状态
        输入：卡链接phandle
        输出：0-有效， 1- 无效
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadElStates")]
        public static extern Int32 SMCReadElStates(IntPtr phandle, Byte iaxis, ref Byte pElDecState, ref Byte pElPlusState);


        /*************************************************************
        说明：读减速信号输入状态
        输入：卡链接phandle io编号，从1开始
        输出：0-有效， 1- 无效
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadSdStates")]
        public static extern Int32 SMCReadSdStates(IntPtr phandle, Byte iaxis, ref Byte pIoState);

        /*************************************************************
        说明：读到位信号输入状态
        输入：卡链接phandle io编号，从1开始
        输出：0-有效， 1- 无效
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadInpStates")]
        public static extern Int32 SMCReadInpStates(IntPtr phandle, Byte iaxis, ref Byte pIoState);

        /*************************************************************
        说明：写PWM占空比
        输入：卡链接phandle 通道:1/2
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWritePwmDuty")]
        public static extern Int32 SMCWritePwmDuty(IntPtr phandle, Byte ichannel, float fDuty);
        /*************************************************************
        说明：写PWM频率
        输入：卡链接phandle 通道:1/2
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWritePwmFreqency")]
        public static extern Int32 SMCWritePwmFreqency(IntPtr phandle, Byte ichannel, float fFre);

        /*************************************************************
        说明：写DA输出电压
        输入：卡链接phandle 通道:1/2
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCWriteDaOut")]
        public static extern Int32 SMCWriteDaOut(IntPtr phandle, Byte ichannel, float fLevel);

        /*************************************************************
        说明：PWM占空比
        输入：卡链接phandle 通道:1/2
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadPwmDuty")]
        public static extern Int32 SMCReadPwmDuty(IntPtr phandle, Byte ichannel, ref float fDuty);

        /*************************************************************
        说明：PWM频率
        输入：卡链接phandle 通道:1/2
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadPwmFreqency")]
        public static extern Int32 SMCReadPwmFreqency(IntPtr phandle, Byte ichannel, ref float fFre);

        /*************************************************************
        说明：DA输出电压
        输入：卡链接phandle 通道:1/2
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCReadDaOut")]
        public static extern Int32 SMCReadDaOut(IntPtr phandle, Byte ichannel, ref float fLevel);


        /*************************************************************
        说明：客户编号, 这个函数只对部分客户开放
        输入：卡链接phandle
        输出：状态
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetClientId")]
       public static extern Int32 SMCGetClientId(IntPtr phandle,ref Int32 pId);

        /*************************************************************
        说明：软件产品类型
        输入：卡链接phandle
        输出：状态
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetSoftwareId")]
        public static extern Int32 SMCGetSoftwareId(IntPtr phandle,ref Int32 pId);


        /*************************************************************
        说明：硬件编号
        输入：卡链接phandle
        输出：状态
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetHardwareId")]
        public static extern Int32 SMCGetHardwareId(IntPtr phandle,ref Int32 pId);


        /*************************************************************
        说明：软件版本号，用日期标识
        输入：卡链接phandle
        输出：状态
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetSoftwareVersion")]
        public static extern Int32 SMCGetSoftwareVersion(IntPtr phandle,ref Int32 pVersion);

        /*************************************************************
        说明：上传密码文件
        输入：卡链接phandle 内存buff
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpPasswordFile")] 
        public static extern Int32 SMCUpPasswordFile(IntPtr phandle, string pfilename);

        /*************************************************************
        说明：上传密码文件
        输入：卡链接phandle 内存buff 返回实际的文件长度
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCUpPasswordFileToMem")] 
        public static extern Int32 SMCUpPasswordFileToMem(IntPtr phandle, ref Byte pbuffer, Int32 buffsize, ref Int32 puifilesize);

        /*************************************************************
        说明：下载密码文件
        输入：卡链接phandle 文件名
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownPasswordFile")] 
         public static extern Int32 SMCDownPasswordFile(IntPtr phandle, string pfilename);


        /*************************************************************
        说明：下载密码文件, 文本文件的长度用strlen 即可
        输入：卡链接phandle buff 
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCDownMemPasswordFile")]
         public static extern Int32 SMCDownMemPasswordFile(IntPtr phandle, string pbuffer, Int32 buffsize);


        /*************************************************************
        说明：输入密码
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterSetPassword")] 
         public static extern Int32 SMCEnterSetPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        说明：输入密码
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterEditPassword")] 
         public static extern Int32 SMCEnterEditPassword(IntPtr phandle, Int32 uipassword);


        /*************************************************************
        说明：输入密码
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterSuperPassword")] 
         public static extern Int32 SMCEnterSuperPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        说明：输入密码
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCEnterTimePassword")]
         public static extern Int32 SMCEnterTimePassword(IntPtr phandle, Int32 uipassword);


        /*************************************************************
        说明：清除已经输入的密码, 必须再次输入密码才能进行相应操作
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCClearEnteredPassword")]
         public static extern Int32 SMCClearEnteredPassword(IntPtr phandle);

        /*************************************************************
        说明：修改密码
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModifySetPassword")] 
         public static extern Int32 SMCModifySetPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        说明：修改密码
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModifyEditPassword")] 
        public static extern Int32 SMCModifyEditPassword(IntPtr phandle, Int32 uipassword);

        /*************************************************************
        说明：修改密码
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModifySuperPassword")]
         public static extern Int32 SMCModifySuperPassword(IntPtr phandle, Int32 uipassword);
        /*************************************************************
        说明：获取用户试用情况
        输入：卡链接phandle 密码
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetTrialCondition")] 
         public static extern Int32 SMCGetTrialCondition(IntPtr phandle, ref Int32 pRunHours, ref Int32 pbifTimeLocked, ref Int32 pAlreadyEnterdTimePasswordNum);



        /*************************************************************
        说明：modbus寄存器操作
        输入：卡链接phandle 寄存器地址
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Set0x")] 
        public static extern Int32 SMCModbus_Set0x(IntPtr phandle, Int32 start, Int32 inum, ref Byte pdata);

        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Get0x")] 
        public static extern Int32 SMCModbus_Get0x(IntPtr phandle, Int32 start, Int32 inum, ref Byte pdata);

        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Get4x")] 
        public static extern Int32 SMCModbus_Get4x(IntPtr phandle, Int32 start, Int32 inum, ref Int32 pdata);

        [DllImport("smc6x.dll", EntryPoint = "SMCModbus_Set4x")]
        public static extern Int32 SMCModbus_Set4x(IntPtr phandle, Int32 start, Int32 inum, ref Int32 pdata);



        /*************************************************************
        说明：检查程序语法
        输入：错误字符串缓存，至少1024字节
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCCheckProgramSyntax")] 
        public static extern Int32 SMCCheckProgramSyntax(string sin, ref Byte sError);

        [DllImport("smc6x.dll", EntryPoint = "SMC_MultiLine")]
        public static extern Int32 SMC_MultiLine(IntPtr phandle,Byte itotalaxis, ref Byte piaxisList, Int32 uiSectes, ref double DistanceList, ref double dspeedList, Byte bIfAbs);


        /*ADD*/
        /*************************************************************
        说明： 设置S曲线比例
        输入：axis 轴号
	           para 曲线比例
        输出：无
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCLineScureSet")] 
        public static extern Int32 SMCLineScureSet(IntPtr phandle,Byte axis,double para);

        /*************************************************************
        说明：设置工件零点
        输入：卡链接phandle 轴号0-3 坐标
        输出：
        返回值：错误码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetWorkOriginPosition")] 
        public static extern Int32 SMCSetWorkOriginPosition(IntPtr phandle, Byte iaxis, double dposition);


        /*************************************************************
        功能：设置/读取软件限位的使能, 限位数值, 响应动作
        参数：axis 指定轴号
	          ON_OFF 软限位使能， 0 –禁止； 1 –使能
              SL_action 限位动作， 0 –急停， 1 –减速停
              N_limit 负限位值
              P_limit 正限位值
        返回值：错误代码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCConfigSoftlimit")]
        public static extern Int32 SMCConfigSoftlimit(IntPtr phandle, Byte axis, Byte ON_OFF,Byte SL_action,float N_limit,float Plimit);


        /*************************************************************
        功能：设置/读取软件限位的使能, 限位数值, 响应动作
        参数：axis 指定轴号
	          ON_OFF 软限位使能， 0 –禁止； 1 –使能
              SL_action 限位动作， 0 –急停， 1 –减速停
              N_limit 负限位值
              P_limit 正限位值
        返回值：错误代码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetConfigSoftlimit")] 
        public static extern Int32 SMCGetConfigSoftlimit(IntPtr phandle, Byte axis, ref Byte  ON_OFF,ref Byte  SL_action,ref float N_limit,ref float Plimit);
        /*************************************************************
        功能：设置/读取间隙补偿值
        参数：axis 指定轴号
        backlash 间隙补偿值， 单位：脉冲
        返回值：错误代码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCSetBackLash")]
        public static extern Int32 SMCSetBackLash(IntPtr phandle, Byte axis, Int32 lash );
        /*************************************************************
        功能：设置/读取间隙补偿值
        参数：axis 指定轴号
        backlash 间隙补偿值， 单位：脉冲
        返回值：错误代码
        *************************************************************/
        [DllImport("smc6x.dll", EntryPoint = "SMCGetBackLash")]
        public static extern Int32 SMCGetBackLash(IntPtr phandle, Byte axis, ref Int32 lash );


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
        [DllImport("smc6x.dll", EntryPoint = "SMCConfigHomeMode")] 
        public static extern Int32 SMCConfigHomeMode(IntPtr phandle, Byte axis,Byte home_dir,double vel,Byte mode);
    }
}


