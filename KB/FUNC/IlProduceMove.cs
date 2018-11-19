using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using KB.BLL;
using KB.DAL;
using KB.Models;

namespace KB.FUNC
{
    public class IlProduceMove
    {

        #region 参数
        DBHelper db = new DBHelper();
        private IList<KB.Models.DATA0038> list = null;

        private int IntD06Rkey = 0;
        //private int ROOT_PTR = 0;
        private int IntD56Rkey = 0;
        private int QTY_BACKLOG = 0;
        private int FQUAN_BACKLOG = 0;
        private int SQUAN_BACKLOG = 0;

        private int RQTY_BACKLOG = 0;
        private int RFQUAN_BACKLOG = 0;
        private int RSQUAN_BACKLOG = 0;
        private int IntD50Rkey = 0;

        private int INVENTORY_PTR = 0;
        private Boolean Switch_grant = false;//内层工单完成，外层自动发放

        private bool autoR = false;//自动送检

        #endregion

        #region 过数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="d06key">工单指针</param>
        /// <param name="starStep">开始步骤</param>
        /// <param name="endStep">结束步骤</param>
        /// <param name="panelQty">过数 panel 数量</param>
        /// <param name="setQty">过数 set 数量</param>
        /// <param name="pcsQty">过数 pcs 数量</param>
       
        public int MoveWorkOrder(int d06key, int starStep, int endStep, int panelQty, int setQty, int pcsQty)
        {
            int returnValue = 0;
             int panelReview=0;
             int setReview=0;
             int pcsReview=0;
             bool autoReview = false;
            DATA0056 d56info = new DATA0056();
            DATA0056BLL bll56 = new DATA0056BLL(db);
            DATA0006BLL bll06 = new DATA0006BLL(db);

            IntD06Rkey = d06key;
            IntD56Rkey = (int)bll56.FindBySql("WO_PTR=" + IntD06Rkey.ToString() + "and step=" + starStep.ToString())[0].RKEY;
            IntD50Rkey = (int)bll06.getDATA0006ByRKEY(d06key).CUST_PART_PTR;
            INVENTORY_PTR = (int)bll06.getDATA0006ByRKEY(d06key).INVENTORY_PTR;

            QTY_BACKLOG = pcsQty;
            FQUAN_BACKLOG = panelQty;
         SQUAN_BACKLOG = setQty;
            autoR = autoReview;
            if (autoReview == false)
            {
                RQTY_BACKLOG = 0;
                RFQUAN_BACKLOG = 0;
                RSQUAN_BACKLOG = 0;

            }
            else
            {
                RQTY_BACKLOG = pcsReview;
                RFQUAN_BACKLOG = panelReview;
                RSQUAN_BACKLOG = setReview;

            }
            if (bll56.FindBySql("WO_PTR=" + d06key.ToString() + " and STEP=" + endStep.ToString()).Count == 0)
            {
              returnValue=  Date_processing(starStep, endStep);
            }
            else
            {

              returnValue=  Date_processing_Part(starStep, endStep);
            }
            log.Info( "外协过数日志："+d06key.ToString()+","+starStep.ToString()+","+ endStep.ToString()+","+panelQty.ToString()+","+setQty.ToString()+","+ pcsQty.ToString());

            return returnValue;
        }
        #endregion

        #region 报废
        /// <summary>
        /// 报废
        /// </summary>
        /// <param name="woPtr">工单指针</param>
        /// <param name="stepNumber">当前步骤</param>
        /// <param name="deptPtr">报废工序</param>
        /// <param name="unitPtr">过数单位指针</param>
        /// <param name="list">格式：数量,39表指针</param>
        /// <returns></returns>
        public int Reject(decimal woPtr, decimal stepNumber, decimal deptPtr, decimal unitPtr, List<string> list)
        {
            int returnValue = 0;
            returnValue = Date_processing_Reject(woPtr, stepNumber, deptPtr, unitPtr,  list);
            return returnValue;

        }
        #endregion


        #region  中间过数站点处理非分批过数
        /// <summary>
        /// 中间过数站点处理
        /// </summary>
        /// <param name="step"></param>
        /// <param name="next_step"></param>
        private int Date_processing(int step, int next_step)
        {
            int returnValue = 0;
            Switch_grant = Func.HasSwitch(5);

            #region 数据类及变量初始化
            int WIP_APPROVAL_FLAG = 0;
            string Hold = "N";
            //D0440BLL bll440 = new D0440BLL(db);
            DATA0038BLL bll38 = new DATA0038BLL(db);
            DATA0034BLL bll34 = new DATA0034BLL(db);
            DATA0056 d56info = new DATA0056();
            DATA0056BLL bll56 = new DATA0056BLL(db);
            DATA0048 d48info = new DATA0048();
            DATA0048BLL bll48 = new DATA0048BLL(db);
            DATA0057 d57info = new DATA0057();
            DATA0057BLL bll57 = new DATA0057BLL(db);
            DATA0058 d58info = new DATA0058();
            DATA0058BLL bll58 = new DATA0058BLL(db);
            DATA0505 d505info = new DATA0505();
            DATA0505BLL bll505 = new DATA0505BLL(db);
            DATA0553 d553info = new DATA0553();
            DATA0553BLL bll553 = new DATA0553BLL(db);
            DATA9155 d9155info = new DATA9155();
            DATA9155BLL bll9155 = new DATA9155BLL(db);
            DATA0006 d06info = new DATA0006();
            DATA0006BLL bll06 = new DATA0006BLL(db);
            DATA0053 d53info = new DATA0053();
            DATA0053BLL bll53 = new DATA0053BLL(db);
            DATA0050 d50info = new DATA0050();
            DATA0050BLL bll50 = new DATA0050BLL(db);
            DATA0113 d113info = new DATA0113();
            DATA0113BLL bll113 = new DATA0113BLL(db);

            DATA9139 d9139info = new DATA9139();
            DATA9139BLL bll9139 = new DATA9139BLL(db);

            DATA0117 d117info = new DATA0117();
            DATA0117BLL bll117 = new DATA0117BLL(db);

            DATA0011 d11info = new DATA0011();
            DATA0011BLL bll11 = new DATA0011BLL(db);



            #endregion

            for (int i = step + 1; i <= next_step; i++)
            {

                if (bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + i)[0].STEP_HOLD == "Y")
                {
                    next_step = i;
                    break;
                }
            }

            if (next_step != -1)
            {
                int Max_step = int.Parse(bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 ORDER BY STEP_NUMBER DESC")[0].STEP_NUMBER.ToString());
                list = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + next_step);
                WIP_APPROVAL_FLAG = int.Parse(list[0].WIP_APPROVAL_FLAG.ToString());
                Hold = list[0].STEP_HOLD;
                int D34RKEY1 = int.Parse(bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + step.ToString())[0].DEPT_PTR.ToString());
                if (bll34.getDATA0034ByRKEY(D34RKEY1).TTYPE != "1")
                {
                    D34RKEY1 = (int)bll34.getDATA0034ByRKEY(D34RKEY1).DEPT_PTR;
                }

                int IntDeptRkey = int.Parse(bll34.FindBySql("DEPT_PTR=" + D34RKEY1 + " and TTYPE=3")[0].RKEY.ToString());
                #region 事务处理
                using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 360;
                        try
                        {

                            #region UPDATE DATA0056

                            d56info = bll56.getDATA0056ByRKEY(IntD56Rkey);
                            d56info.QTY_BACKLOG = d56info.QTY_BACKLOG - QTY_BACKLOG < 0 ? 0 : d56info.QTY_BACKLOG - QTY_BACKLOG;
                            d56info.QTY_PRODUCED = d56info.QTY_PRODUCED + QTY_BACKLOG;
                            d56info.QTY_PROD_PANELS = d56info.QTY_PROD_PANELS + FQUAN_BACKLOG;
                            bll56.Update(cmd, conn, trans, d56info);

                            //38860开关打开更新
                            if (Switch_grant == true)
                            {
                                if (bll9139.FindBySql("DATA0056_PTR=" + IntD56Rkey.ToString()).Count > 0)
                                {
                                    int d9139rkey = (int)bll9139.FindBySql("DATA0056_PTR=" + IntD56Rkey.ToString())[0].RKEY;
                                    d9139info = bll9139.getDATA9139ByRKEY(d9139rkey);
                                    d9139info.PHY_QTY_BACKLOG = d9139info.PHY_QTY_BACKLOG - QTY_BACKLOG > 0 ? d9139info.PHY_QTY_BACKLOG - QTY_BACKLOG : 0;
                                    bll9139.Update(cmd, conn, trans, d9139info);
                                }

                            }

                            #endregion

                            #region UPDATE DATA9155

                            int d9155rkey = 0;
                            if (bll9155.FindBySql("SOURCE_PTR=" + IntD56Rkey + " and trantp=1").Count > 0)
                            {
                                d9155rkey = int.Parse(bll9155.FindBySql("SOURCE_PTR=" + IntD56Rkey + " and trantp=1")[0].RKEY.ToString());
                                d9155info = bll9155.getDATA9155ByRKEY(d9155rkey);
                                d9155info.QUAN_BACKLOG = d9155info.QUAN_BACKLOG - QTY_BACKLOG < 0 ? 0 : d9155info.QUAN_BACKLOG - QTY_BACKLOG;
                                d9155info.FQUAN_BACKLOG = d9155info.FQUAN_BACKLOG - FQUAN_BACKLOG < 0 ? 0 : d9155info.FQUAN_BACKLOG - FQUAN_BACKLOG;
                                d9155info.SQUAN_BACKLOG = d9155info.SQUAN_BACKLOG - SQUAN_BACKLOG < 0 ? 0 : d9155info.SQUAN_BACKLOG - SQUAN_BACKLOG;
                                d9155info.QUAN_PROD = d9155info.QUAN_PROD + QTY_BACKLOG;
                                d9155info.FQUAN_PROD = d9155info.FQUAN_PROD + FQUAN_BACKLOG;
                                d9155info.SQUAN_PROD = d9155info.SQUAN_PROD + SQUAN_BACKLOG;
                                if (Switch_grant == true)
                                {
                                    d9155info.QUAN_PHYBACKLOG = d9155info.QUAN_PHYBACKLOG - QTY_BACKLOG < 0 ? 0 : d9155info.QUAN_PHYBACKLOG - QTY_BACKLOG;
                                    d9155info.FQUAN_PHYBACKLOG = d9155info.FQUAN_PHYBACKLOG - FQUAN_BACKLOG < 0 ? 0 : d9155info.FQUAN_PHYBACKLOG - FQUAN_BACKLOG;
                                    d9155info.SQUAN_PHYBACKLOG = d9155info.SQUAN_PHYBACKLOG - SQUAN_BACKLOG < 0 ? 0 : d9155info.SQUAN_PHYBACKLOG - SQUAN_BACKLOG;
                                }

                                bll9155.Update(cmd, conn, trans, d9155info);
                            }
                            #endregion



                            #region Update DATA0006 时间代码


                            if (Hold == "Y")
                            {
                                d06info = bll06.getDATA0006ByRKEY(IntD06Rkey);
                                d06info.PROD_STATUS = 306;
                                bll06.Update(cmd, conn, trans, d06info);

                                #region 自动暂缓日志
                                int d11key = 0;
                                d11info.SOURCE_TYPE = 117;
                                d11info.FILE_POINTER = 0;
                                d11info.NOTE_PAD_LINE_1 = "触发工序暂缓";
                                d11key = bll11.Add(cmd, conn, trans, d11info);

                                int d117rkey = 0;
                                d117info.SOURCE_PTR = IntD06Rkey;
                                d117info.SOURCE_TYPE = 2;
                                d117info.NOTEPAD_PTR = d11key;
                                d117info.USER_PTR = FUNC.GlobalVal.UserInfo.DATA0073RKEY;
                                d117info.EMPL_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                d117info.TDATE = Func.GetNowDate();
                                d117info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                d117info.ACTION = 2;
                                d117rkey = bll117.Add(cmd, conn, trans, d117info);

                                d11info = bll11.getDATA0011ByRKEY(d11key);
                                d11info.FILE_POINTER = d117rkey;
                                bll11.Update(cmd, conn, trans, d11info);
                                #endregion

                            }

                            #endregion

                            #region Insert into DATA0056、DATA0057、DATA0048

                            #region DATA0048(插入本站记录)
                            ///DATA0048(插入本站记录)
                            ///
                            int d48rkey = 0;
                            d48info.WO_PTR = IntD06Rkey;
                            d48info.TPUT_PTR = IntD56Rkey;
                            d48info.PART_BATCH_PTR = 0;
                            d48info.TDATE = Func.GetNowDate();
                            d48info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                            d48info.QTY_PROD = QTY_BACKLOG;
                            d48info.QTY_REJECT = 0;
                            d48info.WORK_CENTER_PTR = IntDeptRkey;
                            d48info.COSTED_FLAG = "N";
                            d48info.REFERENCE_NUMBER = "";
                            d48info.KEYPAD_ID = "0";
                            d48info.QTY_INSP = QTY_BACKLOG;
                            //if (WIP_APPROVAL_FLAG == 1)
                            //    d48info.WIP_APPROVAL_FLAG = 1;
                            //else
                            d48info.WIP_APPROVAL_FLAG = 0;
                            d48rkey = bll48.Add(cmd, conn, trans, d48info);

                            ///DATA9155
                            ///
                            d9155info.TRANTP = 2;
                            d9155info.SOURCE_PTR = d48rkey;
                            d9155info.FQUAN_BACKLOG = 0;
                            d9155info.SQUAN_BACKLOG = 0;
                            d9155info.QUAN_BACKLOG = 0;
                            d9155info.FQUAN_PHYBACKLOG = 0;
                            d9155info.SQUAN_PHYBACKLOG = 0;
                            d9155info.QUAN_PHYBACKLOG = 0;
                            d9155info.FQUAN_PROD = FQUAN_BACKLOG;
                            d9155info.SQUAN_PROD = SQUAN_BACKLOG;
                            d9155info.QUAN_PROD = QTY_BACKLOG;
                            d9155info.FQUAN_REJ = 0;
                            d9155info.SQUAN_REJ = 0;
                            d9155info.QUAN_REJ = 0;
                            d9155info.FQUAN_REVIEW = 0;
                            d9155info.SQUAN_REVIEW = 0;
                            d9155info.QUAN_REVIEW = 0;
                            d9155info.FQUAN_ALLOC = 0;
                            d9155info.SQUAN_ALLOC = 0;
                            d9155info.QUAN_ALLOC = 0;
                            bll9155.Add(cmd, conn, trans, d9155info);
                            ///插入DATA0553 审批日志记录表
                            ///

                            if (WIP_APPROVAL_FLAG == 1)
                            {
                                d553info.DATA48_PTR = d48rkey;
                                d553info.TRANS_TYPE = 1;//2为审批类型
                                d553info.TRANS_DESCRIPTION = "发送审批";
                                d553info.FROM_STEP = step;
                                d553info.TO_STEP = next_step;
                                d553info.FROM_STATUS = 0;
                                d553info.TO_STATUS = 1;
                                d553info.EMPL_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                d553info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                d553info.TRANS_DATETIME = Func.GetNowDate();
                                d553info.PROGRAM_SOURCE = 1;
                                bll553.Add(cmd, conn, trans, d553info);

                                d553info.DATA48_PTR = d48rkey;
                                d553info.TRANS_TYPE = 5;//2为审批类型
                                d553info.TRANS_DESCRIPTION = "忽略审批";
                                d553info.FROM_STEP = step;
                                d553info.TO_STEP = next_step;
                                d553info.FROM_STATUS = 1;
                                d553info.TO_STATUS = 0;
                                d553info.EMPL_PTR = GlobalVal.UserInfo.DATA0005RKEY;
                                d553info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                d553info.TRANS_DATETIME = Func.GetNowDate();
                                d553info.PROGRAM_SOURCE = 2;
                                bll553.Add(cmd, conn, trans, d553info);
                            }

                            d9155info.TRANTP = 9;
                            d9155info.SOURCE_PTR = d48rkey;
                            d9155info.FQUAN_BACKLOG = 0;
                            d9155info.SQUAN_BACKLOG = 0;
                            d9155info.QUAN_BACKLOG = 0;
                            d9155info.FQUAN_PHYBACKLOG = 0;
                            d9155info.SQUAN_PHYBACKLOG = 0;
                            d9155info.QUAN_PHYBACKLOG = 0;
                            d9155info.FQUAN_PROD = 0;
                            d9155info.SQUAN_PROD = 0;
                            d9155info.QUAN_PROD = 0;
                            d9155info.FQUAN_REJ = 0;
                            d9155info.SQUAN_REJ = 0;
                            d9155info.QUAN_REJ = 0;
                            d9155info.FQUAN_REVIEW = FQUAN_BACKLOG;
                            d9155info.SQUAN_REVIEW = SQUAN_BACKLOG;
                            d9155info.QUAN_REVIEW = QTY_BACKLOG;
                            d9155info.FQUAN_ALLOC = 0;
                            d9155info.SQUAN_ALLOC = 0;
                            d9155info.QUAN_ALLOC = 0;
                            bll9155.Add(cmd, conn, trans, d9155info);



                            #endregion

                            #region 若填写待检数量则插入DATA0505
                            if (RQTY_BACKLOG > 0 && autoR == true)
                            {
                                int d505key = 0;
                                d505info.DATA0056_PTR = IntD56Rkey;
                                d505info.DATA0034_PTR = IntDeptRkey;
                                d505info.WO_PTR = IntD06Rkey;
                                d505info.STEP_NO = next_step;
                                d505info.CUST_PART_PTR = IntD50Rkey;
                                d505info.INVENTORY_PART_PTR = INVENTORY_PTR;
                                d505info.DATA0048_PTR = d48rkey;
                                d505info.QTY_TO_BE_REVIEWED = RQTY_BACKLOG;
                                d505info.QTY_REJECTED = 0;
                                d505info.QTY_RETURNED = 0;
                                d505info.EMPL_PTR = GlobalVal.UserInfo.DATA0005RKEY;
                                d505info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                d505info.TRANS_DATE_TIME = Func.GetNowDate();
                                d505info.QTY_PRB_PANELS = RFQUAN_BACKLOG;
                                d505info.QTY_RETURN_PANELS = 0;
                                d505info.QTY_DEFECTED = 0;
                                d505key = bll505.Add(cmd, conn, trans, d505info);




                            }

                            #endregion

                            #region DATA0057(插入本站记录)
                            ///DATA0057(插入本站记录)
                            ///
                            int D57KEY = 0;
                            d57info.W_C_PTR = IntDeptRkey;
                            d57info.TPUT_PTR = IntD56Rkey;
                            d57info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                            d57info.EMPL_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                            d57info.QTY_PROD = QTY_BACKLOG;
                            d57info.TDATE = Func.GetNowDate();
                            d57info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                            d57info.TRAN_PTR = d48rkey;
                            D57KEY = bll57.Add(cmd, conn, trans, d57info);

                            #endregion


                            #region 过数点中间存在不用过数流程
                            if (next_step - step > 1)
                            {
                                //中间非过数点
                                for (int i = step + 1; i < next_step; i++)
                                {
                                    int D34RKEY = int.Parse(bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + i)[0].DEPT_PTR.ToString());
                                    if (bll34.getDATA0034ByRKEY(D34RKEY).TTYPE != "1")
                                    {
                                        D34RKEY = (int)bll34.getDATA0034ByRKEY(D34RKEY).DEPT_PTR;
                                    }



                                    int WC_PTR = int.Parse(bll34.FindBySql("DEPT_PTR=" + D34RKEY + " and TTYPE=3 ")[0].RKEY.ToString());


                                    #region DATA0056 D9155
                                    ///DATA0056
                                    ///
                                    int d56rkey = 0;
                                    d56info.WO_PTR = IntD06Rkey;
                                    d56info.D_G_W_PTR = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + i)[0].DEPT_PTR;
                                    d56info.UNIT_PTR = 0;
                                    d56info.EMPLOYEE_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                    d56info.STEP = i;
                                    d56info.QTY_BACKLOG = 0;
                                    d56info.QTY_PRODUCED = QTY_BACKLOG;
                                    d56info.QTY_REJECTED = 0;
                                    d56info.TDATE = Func.GetNowDate();
                                    d56info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                    d56info.DEPT_PTR = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + i)[0].DEPT_PTR;
                                    d56info.QTY_PROD_PANELS = FQUAN_BACKLOG;
                                    d56info.COSTED_FLAG = "N";
                                    d56info.REWORK_QTY = 0;
                                    d56info.REWORK_LOCATION_PTR = 0;
                                    d56info.CUR_REWORK_TRANS_PTR = 0;
                                    d56info.STEP_YIELD = 0;
                                    d56info.STEP_HOLD = "N";
                                    d56info.QTY_REJ_PANELS = 0;
                                    d56info.NEXT_DEPT_PTR = d56info.NEXT_ROUTED_RESOURCE = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + (i + 1))[0].DEPT_PTR;
                                    d56rkey = bll56.Add(cmd, conn, trans, d56info);
                                    ///DATA9155
                                    ///
                                    d9155info.TRANTP = 1;
                                    d9155info.SOURCE_PTR = d56rkey;
                                    d9155info.FQUAN_BACKLOG = 0;
                                    d9155info.SQUAN_BACKLOG = 0;
                                    d9155info.QUAN_BACKLOG = 0;
                                    d9155info.FQUAN_PHYBACKLOG = 0;
                                    d9155info.SQUAN_PHYBACKLOG = 0;
                                    d9155info.QUAN_PHYBACKLOG = 0;
                                    d9155info.FQUAN_PROD = FQUAN_BACKLOG;
                                    d9155info.SQUAN_PROD = SQUAN_BACKLOG;
                                    d9155info.QUAN_PROD = QTY_BACKLOG;
                                    d9155info.FQUAN_REJ = 0;
                                    d9155info.SQUAN_REJ = 0;
                                    d9155info.QUAN_REJ = 0;
                                    d9155info.FQUAN_REVIEW = 0;
                                    d9155info.SQUAN_REVIEW = 0;
                                    d9155info.QUAN_REVIEW = 0;
                                    d9155info.FQUAN_ALLOC = 0;
                                    d9155info.SQUAN_ALLOC = 0;
                                    d9155info.QUAN_ALLOC = 0;
                                    bll9155.Add(cmd, conn, trans, d9155info);

                                    //9139
                                    if (Switch_grant == true)
                                    {
                                        d9139info.DATA0056_PTR = d56rkey;
                                        d9139info.PHY_QTY_BACKLOG = 0;
                                        bll9139.Add(cmd, conn, trans, d9139info);

                                    }
                                    #endregion

                                    #region DATA0048 D9155
                                    ///DATA0048
                                    ///
                                    int d48rkey_1 = 0;
                                    d48info.WO_PTR = IntD06Rkey;
                                    d48info.TPUT_PTR = d56rkey;
                                    d48info.PART_BATCH_PTR = 0;
                                    d48info.TDATE = Func.GetNowDate();
                                    d48info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                    d48info.QTY_PROD = QTY_BACKLOG;
                                    d48info.QTY_REJECT = 0;
                                    d48info.WORK_CENTER_PTR = WC_PTR;
                                    d48info.COSTED_FLAG = "N";
                                    d48info.REFERENCE_NUMBER = "";
                                    d48info.KEYPAD_ID = "0";
                                    d48info.QTY_INSP = QTY_BACKLOG;
                                    d48info.WIP_APPROVAL_FLAG = 0;
                                    d48rkey_1 = bll48.Add(cmd, conn, trans, d48info);

                                    ///DATA9155
                                    ///
                                    d9155info.TRANTP = 2;
                                    d9155info.SOURCE_PTR = d48rkey_1;
                                    d9155info.FQUAN_BACKLOG = 0;
                                    d9155info.SQUAN_BACKLOG = 0;
                                    d9155info.QUAN_BACKLOG = 0;
                                    d9155info.FQUAN_PHYBACKLOG = 0;
                                    d9155info.SQUAN_PHYBACKLOG = 0;
                                    d9155info.QUAN_PHYBACKLOG = 0;
                                    d9155info.FQUAN_PROD = FQUAN_BACKLOG;
                                    d9155info.SQUAN_PROD = SQUAN_BACKLOG;
                                    d9155info.QUAN_PROD = QTY_BACKLOG;
                                    d9155info.FQUAN_REJ = 0;
                                    d9155info.SQUAN_REJ = 0;
                                    d9155info.QUAN_REJ = 0;
                                    d9155info.FQUAN_REVIEW = 0;
                                    d9155info.SQUAN_REVIEW = 0;
                                    d9155info.QUAN_REVIEW = 0;
                                    d9155info.FQUAN_ALLOC = 0;
                                    d9155info.SQUAN_ALLOC = 0;
                                    d9155info.QUAN_ALLOC = 0;
                                    bll9155.Add(cmd, conn, trans, d9155info);



                                    #endregion



                                    #region DATA057 D9155

                                    ///DATA0057
                                    ///
                                    int d57rkey = 0;
                                    d57info.W_C_PTR = WC_PTR;
                                    d57info.TPUT_PTR = d56rkey;
                                    d57info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                    d57info.EMPL_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                    d57info.QTY_PROD = QTY_BACKLOG;
                                    d57info.TDATE = Func.GetNowDate();
                                    d57info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                    d57info.TRAN_PTR = d48rkey_1;
                                    d57rkey = bll57.Add(cmd, conn, trans, d57info);


                                    #endregion

                                }

                                #region 下一过数点 DATA0056 D9155
                                ///DATA0056
                                ///
                                int d56rkey_02 = 0;
                                d56info.WO_PTR = IntD06Rkey;
                                d56info.D_G_W_PTR = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + next_step)[0].DEPT_PTR;
                                d56info.UNIT_PTR = 0;
                                d56info.EMPLOYEE_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                d56info.STEP = next_step;
                                d56info.QTY_BACKLOG = QTY_BACKLOG;
                                d56info.QTY_PRODUCED = 0;
                                d56info.QTY_REJECTED = 0;
                                d56info.TDATE = Func.GetNowDate();
                                d56info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                d56info.DEPT_PTR = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + next_step)[0].DEPT_PTR;
                                d56info.QTY_PROD_PANELS = 0;
                                d56info.COSTED_FLAG = "N";
                                d56info.REWORK_QTY = 0;
                                d56info.REWORK_LOCATION_PTR = 0;
                                d56info.CUR_REWORK_TRANS_PTR = 0;
                                d56info.STEP_YIELD = 0;
                                d56info.STEP_HOLD = "N";
                                d56info.QTY_REJ_PANELS = 0;
                                if (next_step == Max_step)
                                    d56info.NEXT_DEPT_PTR = d56info.NEXT_ROUTED_RESOURCE = 0;
                                else
                                    d56info.NEXT_DEPT_PTR = d56info.NEXT_ROUTED_RESOURCE = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + (next_step + 1))[0].DEPT_PTR;
                                d56rkey_02 = bll56.Add(cmd, conn, trans, d56info);


                                if (Switch_grant == true)
                                {
                                    if (bll9139.FindBySql("DATA0056_PTR=" + d56rkey_02.ToString()).Count > 0)
                                    {
                                        int d9139rkey = (int)bll9139.FindBySql("DATA0056_PTR=" + d56rkey_02.ToString())[0].RKEY;
                                        d9139info = bll9139.getDATA9139ByRKEY(d9139rkey);
                                        d9139info.PHY_QTY_BACKLOG = d9139info.PHY_QTY_BACKLOG + QTY_BACKLOG;
                                        bll9139.Update(cmd, conn, trans, d9139info);

                                    }
                                    else
                                    {
                                        d9139info.DATA0056_PTR = d56rkey_02;
                                        d9139info.PHY_QTY_BACKLOG = QTY_BACKLOG;
                                        bll9139.Add(cmd, conn, trans, d9139info);
                                    }
                                }
                                ///DATA9155
                                ///
                                d9155info.TRANTP = 1;
                                d9155info.SOURCE_PTR = d56rkey_02;
                                if (bll34.FindBySql("TTYPE=3 AND DEPT_PTR=" + d56info.D_G_W_PTR.ToString())[0].BCODE_UNIT_PTR > 4)
                                {
                                    d9155info.FQUAN_BACKLOG = 0;
                                    if (Switch_grant == true)
                                    {
                                        d9155info.FQUAN_PHYBACKLOG = 0;
                                    }
                                }
                                else
                                {

                                    d9155info.FQUAN_BACKLOG = FQUAN_BACKLOG;
                                    if (Switch_grant == true)
                                    {
                                        d9155info.FQUAN_PHYBACKLOG = FQUAN_BACKLOG;
                                    }
                                }
                                d9155info.SQUAN_BACKLOG = SQUAN_BACKLOG;
                                d9155info.QUAN_BACKLOG = QTY_BACKLOG;
                                if (Switch_grant == true)
                                    d9155info.SQUAN_PHYBACKLOG = SQUAN_BACKLOG;
                                else
                                    d9155info.SQUAN_PHYBACKLOG = 0;
                                if (Switch_grant == true)
                                    d9155info.QUAN_PHYBACKLOG = QTY_BACKLOG;
                                else
                                    d9155info.QUAN_PHYBACKLOG = 0;
                                d9155info.FQUAN_PROD = 0;
                                d9155info.SQUAN_PROD = 0;
                                d9155info.QUAN_PROD = 0;
                                d9155info.FQUAN_REJ = 0;
                                d9155info.SQUAN_REJ = 0;
                                d9155info.QUAN_REJ = 0;
                                d9155info.FQUAN_REVIEW = 0;
                                d9155info.SQUAN_REVIEW = 0;
                                d9155info.QUAN_REVIEW = 0;
                                d9155info.FQUAN_ALLOC = 0;
                                d9155info.SQUAN_ALLOC = 0;
                                d9155info.QUAN_ALLOC = 0;
                                bll9155.Add(cmd, conn, trans, d9155info);



                                #endregion

                            }
                            #endregion

                            #region 过数点中间不存在过数流程
                            else
                            {
                                #region 下一过数点 DATA0056 D9155
                                ///DATA0056
                                ///
                                int d56rkey_03 = 0;
                                d56info.WO_PTR = IntD06Rkey;
                                d56info.D_G_W_PTR = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + next_step)[0].DEPT_PTR;
                                d56info.UNIT_PTR = 0;
                                d56info.EMPLOYEE_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                d56info.STEP = next_step;
                                d56info.QTY_BACKLOG = QTY_BACKLOG;
                                d56info.QTY_PRODUCED = 0;
                                d56info.QTY_REJECTED = 0;
                                d56info.TDATE = Func.GetNowDate();
                                d56info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                d56info.DEPT_PTR = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + next_step)[0].DEPT_PTR;
                                d56info.QTY_PROD_PANELS = 0;
                                d56info.COSTED_FLAG = "N";
                                d56info.REWORK_QTY = 0;
                                d56info.REWORK_LOCATION_PTR = 0;
                                d56info.CUR_REWORK_TRANS_PTR = 0;
                                d56info.STEP_YIELD = 0;
                                d56info.STEP_HOLD = "N";
                                d56info.QTY_REJ_PANELS = 0;
                                if (next_step == Max_step)
                                    d56info.NEXT_DEPT_PTR = d56info.NEXT_ROUTED_RESOURCE = 0;
                                else
                                    d56info.NEXT_DEPT_PTR = d56info.NEXT_ROUTED_RESOURCE = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + (next_step + 1))[0].DEPT_PTR;
                                d56rkey_03 = bll56.Add(cmd, conn, trans, d56info);

                                if (Switch_grant == true)
                                {
                                    if (bll9139.FindBySql("DATA0056_PTR=" + d56rkey_03.ToString()).Count > 0)
                                    {
                                        int d9139rkey = (int)bll9139.FindBySql("DATA0056_PTR=" + d56rkey_03.ToString())[0].RKEY;
                                        d9139info = bll9139.getDATA9139ByRKEY(d9139rkey);
                                        d9139info.PHY_QTY_BACKLOG = d9139info.PHY_QTY_BACKLOG + QTY_BACKLOG;
                                        bll9139.Update(cmd, conn, trans, d9139info);

                                    }
                                    else
                                    {
                                        d9139info.DATA0056_PTR = d56rkey_03;
                                        d9139info.PHY_QTY_BACKLOG = QTY_BACKLOG;
                                        bll9139.Add(cmd, conn, trans, d9139info);
                                    }
                                }

                                ///DATA9155
                                ///
                                d9155info.TRANTP = 1;
                                d9155info.SOURCE_PTR = d56rkey_03;

                                int key34 = (int)d56info.D_G_W_PTR;
                                if (bll34.getDATA0034ByRKEY(d56info.D_G_W_PTR).TTYPE != "1")
                                {
                                    key34 = (int)bll34.getDATA0034ByRKEY(d56info.D_G_W_PTR).DEPT_PTR;
                                }
                                if (bll34.FindBySql("TTYPE=3 AND DEPT_PTR=" + key34.ToString())[0].BCODE_UNIT_PTR > 4)
                                {
                                    d9155info.FQUAN_BACKLOG = 0;
                                    if (Switch_grant == true)
                                    {
                                        d9155info.FQUAN_PHYBACKLOG = 0;
                                    }
                                }
                                else
                                {
                                    d9155info.FQUAN_BACKLOG = FQUAN_BACKLOG;
                                    if (Switch_grant == true)
                                    {
                                        d9155info.FQUAN_PHYBACKLOG = FQUAN_BACKLOG;
                                    }
                                }
                                d9155info.SQUAN_BACKLOG = SQUAN_BACKLOG;
                                d9155info.QUAN_BACKLOG = QTY_BACKLOG;
                                //d9155info.FQUAN_PHYBACKLOG = 0;
                                if (Switch_grant == true)
                                    d9155info.SQUAN_PHYBACKLOG = SQUAN_BACKLOG;
                                else
                                    d9155info.SQUAN_PHYBACKLOG = 0;
                                if (Switch_grant == true)
                                    d9155info.QUAN_PHYBACKLOG = QTY_BACKLOG;
                                else
                                    d9155info.QUAN_PHYBACKLOG = 0;
                                d9155info.FQUAN_PROD = 0;
                                d9155info.SQUAN_PROD = 0;
                                d9155info.QUAN_PROD = 0;
                                d9155info.FQUAN_REJ = 0;
                                d9155info.SQUAN_REJ = 0;
                                d9155info.QUAN_REJ = 0;
                                d9155info.FQUAN_REVIEW = 0;
                                d9155info.SQUAN_REVIEW = 0;
                                d9155info.QUAN_REVIEW = 0;
                                d9155info.FQUAN_ALLOC = 0;
                                d9155info.SQUAN_ALLOC = 0;
                                d9155info.QUAN_ALLOC = 0;
                                bll9155.Add(cmd, conn, trans, d9155info);



                                #endregion

                            }
                            #endregion


                            #endregion



                            
                            trans.Commit();
                            // this.Close();
                            // MessageBox.Show("数据处理完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = 1;
                        }
                        catch (Exception ee)
                        {
                            //img = "E";
                            trans.Rollback();//异常回滚
                            log.PrintInfo(ee);
                            MessageBox.Show("数据处理失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                #endregion


            }

            return returnValue;
        }
        #endregion

        #region  中间过数站点处理分批过数
        /// <summary>
        /// 中间过数站点处理
        /// </summary>
        /// <param name="step"></param>
        /// <param name="next_step"></param>
        private int Date_processing_Part(int step, int next_step)
        {
            int returnValue = 0;
            Switch_grant = Func.HasSwitch(5);
            #region 数据类及变量初始化
            int WIP_APPROVAL_FLAG = 0;
            string Hold = "N";
            //D0440BLL bll440 = new D0440BLL(db);
            DATA0038BLL bll38 = new DATA0038BLL(db);
            DATA0034BLL bll34 = new DATA0034BLL(db);
            DATA0056 d56info = new DATA0056();
            DATA0056BLL bll56 = new DATA0056BLL(db);
            DATA0048 d48info = new DATA0048();
            DATA0048BLL bll48 = new DATA0048BLL(db);
            DATA0057 d57info = new DATA0057();
            DATA0057BLL bll57 = new DATA0057BLL(db);
            DATA0058 d58info = new DATA0058();
            DATA0058BLL bll58 = new DATA0058BLL(db);
            DATA0505 d505info = new DATA0505();
            DATA0505BLL bll505 = new DATA0505BLL(db);
            DATA0553 d553info = new DATA0553();
            DATA0553BLL bll553 = new DATA0553BLL(db);
            DATA9155 d9155info = new DATA9155();
            DATA9155BLL bll9155 = new DATA9155BLL(db);
            DATA0006 d06info = new DATA0006();
            DATA0006BLL bll06 = new DATA0006BLL(db);
            DATA0053 d53info = new DATA0053();
            DATA0053BLL bll53 = new DATA0053BLL(db);
            DATA0050 d50info = new DATA0050();
            DATA0050BLL bll50 = new DATA0050BLL(db);
            DATA0113 d113info = new DATA0113();
            DATA0113BLL bll113 = new DATA0113BLL(db);

            DATA9139 d9139info = new DATA9139();
            DATA9139BLL bll9139 = new DATA9139BLL(db);

            DATA0117 d117info = new DATA0117();
            DATA0117BLL bll117 = new DATA0117BLL(db);

            DATA0011 d11info = new DATA0011();
            DATA0011BLL bll11 = new DATA0011BLL(db);



            #endregion


            if (next_step != -1)
            {
                int Max_step = int.Parse(bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 ORDER BY STEP_NUMBER DESC")[0].STEP_NUMBER.ToString());
                list = bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + next_step);
                WIP_APPROVAL_FLAG = int.Parse(list[0].WIP_APPROVAL_FLAG.ToString());
                Hold = list[0].STEP_HOLD;
                int D34RKEY1 = int.Parse(bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + step.ToString())[0].DEPT_PTR.ToString());
                if (bll34.getDATA0034ByRKEY(D34RKEY1).TTYPE != "1")
                {
                    D34RKEY1 = (int)bll34.getDATA0034ByRKEY(D34RKEY1).DEPT_PTR;
                }

                int IntDeptRkey = int.Parse(bll34.FindBySql("DEPT_PTR=" + D34RKEY1 + " and TTYPE=3")[0].RKEY.ToString());
                using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 360;
                        try
                        {


                            #region UPDATE DATA0056

                            d56info = bll56.getDATA0056ByRKEY(IntD56Rkey);
                            d56info.QTY_BACKLOG = d56info.QTY_BACKLOG - QTY_BACKLOG < 0 ? 0 : d56info.QTY_BACKLOG - QTY_BACKLOG;
                            d56info.QTY_PRODUCED = d56info.QTY_PRODUCED + QTY_BACKLOG;
                            d56info.QTY_PROD_PANELS = d56info.QTY_PROD_PANELS + FQUAN_BACKLOG;
                            bll56.Update(cmd, conn, trans, d56info);

                            //38860开关打开更新
                            if (Switch_grant == true)
                            {
                                if (bll9139.FindBySql("DATA0056_PTR=" + IntD56Rkey.ToString()).Count > 0)
                                {
                                    int d9139rkey = (int)bll9139.FindBySql("DATA0056_PTR=" + IntD56Rkey.ToString())[0].RKEY;
                                    d9139info = bll9139.getDATA9139ByRKEY(d9139rkey);
                                    d9139info.PHY_QTY_BACKLOG = d9139info.PHY_QTY_BACKLOG - QTY_BACKLOG > 0 ? d9139info.PHY_QTY_BACKLOG - QTY_BACKLOG : 0;
                                    bll9139.Update(cmd, conn, trans, d9139info);
                                }

                            }

                            #endregion

                            #region UPDATE DATA9155

                            int d9155rkey = 0;
                            if (bll9155.FindBySql("SOURCE_PTR=" + IntD56Rkey + " and trantp=1").Count > 0)
                            {
                                d9155rkey = int.Parse(bll9155.FindBySql("SOURCE_PTR=" + IntD56Rkey + " and trantp=1")[0].RKEY.ToString());
                                d9155info = bll9155.getDATA9155ByRKEY(d9155rkey);
                                d9155info.QUAN_BACKLOG = d9155info.QUAN_BACKLOG - QTY_BACKLOG < 0 ? 0 : d9155info.QUAN_BACKLOG - QTY_BACKLOG;
                                d9155info.FQUAN_BACKLOG = d9155info.FQUAN_BACKLOG - FQUAN_BACKLOG < 0 ? 0 : d9155info.FQUAN_BACKLOG - FQUAN_BACKLOG;
                                d9155info.SQUAN_BACKLOG = d9155info.SQUAN_BACKLOG - SQUAN_BACKLOG < 0 ? 0 : d9155info.SQUAN_BACKLOG - SQUAN_BACKLOG;
                                d9155info.QUAN_PROD = d9155info.QUAN_PROD + QTY_BACKLOG;
                                d9155info.FQUAN_PROD = d9155info.FQUAN_PROD + FQUAN_BACKLOG;
                                d9155info.SQUAN_PROD = d9155info.SQUAN_PROD + SQUAN_BACKLOG;
                                if (Switch_grant == true)
                                {
                                    d9155info.QUAN_PHYBACKLOG = d9155info.QUAN_PHYBACKLOG - QTY_BACKLOG < 0 ? 0 : d9155info.QUAN_PHYBACKLOG - QTY_BACKLOG;
                                    d9155info.FQUAN_PHYBACKLOG = d9155info.FQUAN_PHYBACKLOG - FQUAN_BACKLOG < 0 ? 0 : d9155info.FQUAN_PHYBACKLOG - FQUAN_BACKLOG;
                                    d9155info.SQUAN_PHYBACKLOG = d9155info.SQUAN_PHYBACKLOG - SQUAN_BACKLOG < 0 ? 0 : d9155info.SQUAN_PHYBACKLOG - SQUAN_BACKLOG;
                                }
                                bll9155.Update(cmd, conn, trans, d9155info);
                            }
                            #endregion



                            #region Update DATA0006 时间代码


                            if (Hold == "Y")
                            {
                                d06info = bll06.getDATA0006ByRKEY(IntD06Rkey);
                                d06info.PROD_STATUS = 306;
                                bll06.Update(cmd, conn, trans, d06info);

                                #region 自动暂缓日志
                                int d11key = 0;
                                d11info.SOURCE_TYPE = 117;
                                d11info.FILE_POINTER = 0;
                                d11info.NOTE_PAD_LINE_1 = "触发工序暂缓";
                                d11key = bll11.Add(cmd, conn, trans, d11info);

                                int d117rkey = 0;
                                d117info.SOURCE_PTR = IntD06Rkey;
                                d117info.SOURCE_TYPE = 2;
                                d117info.NOTEPAD_PTR = d11key;
                                d117info.USER_PTR = FUNC.GlobalVal.UserInfo.DATA0073RKEY;
                                d117info.EMPL_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                d117info.TDATE = Func.GetNowDate();
                                d117info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                d117info.ACTION = 2;
                                d117rkey = bll117.Add(cmd, conn, trans, d117info);

                                d11info = bll11.getDATA0011ByRKEY(d11key);
                                d11info.FILE_POINTER = d117rkey;
                                bll11.Update(cmd, conn, trans, d11info);
                                #endregion
                            }

                            #endregion

                            #region Insert into DATA0056、DATA0057、DATA0048

                            #region DATA0048(插入本站记录)
                            ///DATA0048(插入本站记录)
                            ///
                            int d48rkey = 0;
                            d48info.WO_PTR = IntD06Rkey;
                            d48info.TPUT_PTR = IntD56Rkey;
                            d48info.PART_BATCH_PTR = 0;
                            d48info.TDATE = Func.GetNowDate();
                            d48info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                            d48info.QTY_PROD = QTY_BACKLOG;
                            d48info.QTY_REJECT = 0;
                            d48info.WORK_CENTER_PTR = IntDeptRkey;
                            d48info.COSTED_FLAG = "N";
                            d48info.REFERENCE_NUMBER = "";
                            d48info.KEYPAD_ID = "0";
                            d48info.QTY_INSP = QTY_BACKLOG;
                            //if (WIP_APPROVAL_FLAG == 1)
                            //    d48info.WIP_APPROVAL_FLAG = 1;
                            //else
                            d48info.WIP_APPROVAL_FLAG = 0;
                            d48rkey = bll48.Add(cmd, conn, trans, d48info);

                            ///DATA9155
                            ///
                            d9155info.TRANTP = 2;
                            d9155info.SOURCE_PTR = d48rkey;
                            d9155info.FQUAN_BACKLOG = 0;
                            d9155info.SQUAN_BACKLOG = 0;
                            d9155info.QUAN_BACKLOG = 0;
                            d9155info.FQUAN_PHYBACKLOG = 0;
                            d9155info.SQUAN_PHYBACKLOG = 0;
                            d9155info.QUAN_PHYBACKLOG = 0;
                            d9155info.FQUAN_PROD = FQUAN_BACKLOG;
                            d9155info.SQUAN_PROD = SQUAN_BACKLOG;
                            d9155info.QUAN_PROD = QTY_BACKLOG;
                            d9155info.FQUAN_REJ = 0;
                            d9155info.SQUAN_REJ = 0;
                            d9155info.QUAN_REJ = 0;
                            d9155info.FQUAN_REVIEW = 0;
                            d9155info.SQUAN_REVIEW = 0;
                            d9155info.QUAN_REVIEW = 0;
                            d9155info.FQUAN_ALLOC = 0;
                            d9155info.SQUAN_ALLOC = 0;
                            d9155info.QUAN_ALLOC = 0;
                            bll9155.Add(cmd, conn, trans, d9155info);
                            ///插入DATA0553 审批日志记录表
                            ///

                            if (WIP_APPROVAL_FLAG == 1)
                            {
                                d553info.DATA48_PTR = d48rkey;
                                d553info.TRANS_TYPE = 1;//2为审批类型
                                d553info.TRANS_DESCRIPTION = "发送审批";
                                d553info.FROM_STEP = step;
                                d553info.TO_STEP = next_step;
                                d553info.FROM_STATUS = 0;
                                d553info.TO_STATUS = 1;
                                d553info.EMPL_PTR = GlobalVal.UserInfo.DATA0005RKEY;
                                d553info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                d553info.TRANS_DATETIME = Func.GetNowDate();
                                d553info.PROGRAM_SOURCE = 1;
                                bll553.Add(cmd, conn, trans, d553info);

                                d553info.DATA48_PTR = d48rkey;
                                d553info.TRANS_TYPE = 5;//2为审批类型
                                d553info.TRANS_DESCRIPTION = "忽略审批";
                                d553info.FROM_STEP = step;
                                d553info.TO_STEP = next_step;
                                d553info.FROM_STATUS = 1;
                                d553info.TO_STATUS = 0;
                                d553info.EMPL_PTR = GlobalVal.UserInfo.DATA0005RKEY;
                                d553info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                d553info.TRANS_DATETIME = Func.GetNowDate();
                                d553info.PROGRAM_SOURCE = 2;
                                bll553.Add(cmd, conn, trans, d553info);
                            }

                            d9155info.TRANTP = 9;
                            d9155info.SOURCE_PTR = d48rkey;
                            d9155info.FQUAN_BACKLOG = 0;
                            d9155info.SQUAN_BACKLOG = 0;
                            d9155info.QUAN_BACKLOG = 0;
                            d9155info.FQUAN_PHYBACKLOG = 0;
                            d9155info.SQUAN_PHYBACKLOG = 0;
                            d9155info.QUAN_PHYBACKLOG = 0;
                            d9155info.FQUAN_PROD = 0;
                            d9155info.SQUAN_PROD = 0;
                            d9155info.QUAN_PROD = 0;
                            d9155info.FQUAN_REJ = 0;
                            d9155info.SQUAN_REJ = 0;
                            d9155info.QUAN_REJ = 0;
                            d9155info.FQUAN_REVIEW = FQUAN_BACKLOG;
                            d9155info.SQUAN_REVIEW = SQUAN_BACKLOG;
                            d9155info.QUAN_REVIEW = QTY_BACKLOG;
                            d9155info.FQUAN_ALLOC = 0;
                            d9155info.SQUAN_ALLOC = 0;
                            d9155info.QUAN_ALLOC = 0;
                            bll9155.Add(cmd, conn, trans, d9155info);

                            #endregion

                            #region DATA0057(插入本站记录)
                            ///DATA0057(插入本站记录)
                            ///
                            int D57KEY = 0;
                            d57info.W_C_PTR = IntDeptRkey;
                            d57info.TPUT_PTR = IntD56Rkey;
                            d57info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                            d57info.EMPL_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                            d57info.QTY_PROD = QTY_BACKLOG;
                            d57info.TDATE = Func.GetNowDate();
                            d57info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                            d57info.TRAN_PTR = d48rkey;
                            D57KEY = bll57.Add(cmd, conn, trans, d57info);

                            #endregion

                            #region 若填写待检数量则插入DATA0505
                            if (RQTY_BACKLOG > 0 && autoR == true)
                            {
                                int d505key = 0;
                                d505info.DATA0056_PTR = IntD56Rkey;
                                d505info.DATA0034_PTR = IntDeptRkey;
                                d505info.WO_PTR = IntD06Rkey;
                                d505info.STEP_NO = next_step;
                                d505info.CUST_PART_PTR = IntD50Rkey;
                                d505info.INVENTORY_PART_PTR = INVENTORY_PTR;
                                d505info.DATA0048_PTR = d48rkey;
                                d505info.QTY_TO_BE_REVIEWED = RQTY_BACKLOG;
                                d505info.QTY_REJECTED = 0;
                                d505info.QTY_RETURNED = 0;
                                d505info.EMPL_PTR = GlobalVal.UserInfo.DATA0005RKEY;
                                d505info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                d505info.TRANS_DATE_TIME = Func.GetNowDate();
                                d505info.QTY_PRB_PANELS = RFQUAN_BACKLOG;
                                d505info.QTY_RETURN_PANELS = 0;
                                d505info.QTY_DEFECTED = 0;
                                d505key = bll505.Add(cmd, conn, trans, d505info);




                            }

                            #endregion

                            #region 过数点中间存在不用过数流程
                            if (next_step - step > 1)
                            {
                                //中间非过数点
                                for (int i = step + 1; i < next_step; i++)
                                {
                                    int D34RKEY = int.Parse(bll38.FindBySql("SOURCE_PTR=" + IntD06Rkey + " and TTYPE=2 and STEP_NUMBER=" + i)[0].DEPT_PTR.ToString());
                                    if (bll34.getDATA0034ByRKEY(D34RKEY).TTYPE != "1")
                                    {
                                        D34RKEY = (int)bll34.getDATA0034ByRKEY(D34RKEY).DEPT_PTR;
                                    }

                                    int WC_PTR = int.Parse(bll34.FindBySql("DEPT_PTR=" + D34RKEY + " and TTYPE=3 ")[0].RKEY.ToString());

                                    #region UDATE DATA0056 D9155
                                    ///DATA0056
                                    ///
                                    int d56rkey = 0;
                                    d56rkey = int.Parse(bll56.FindBySql("WO_PTR=" + IntD06Rkey + " and STEP=" + i)[0].RKEY.ToString());
                                    d56info = bll56.getDATA0056ByRKEY(d56rkey);
                                    //d56info.QTY_BACKLOG = d56info.QTY_BACKLOG - QTY_BACKLOG < 0 ? 0 : d56info.QTY_BACKLOG - QTY_BACKLOG;
                                    d56info.QTY_PRODUCED = d56info.QTY_PRODUCED + QTY_BACKLOG;
                                    d56info.QTY_PROD_PANELS = d56info.QTY_PROD_PANELS + FQUAN_BACKLOG;
                                    bll56.Update(cmd, conn, trans, d56info);

                                    ///DATA9155
                                    ///
                                    int d9155rkey_1 = 0;
                                    if (bll9155.FindBySql("SOURCE_PTR=" + d56rkey + " and trantp=1").Count > 0)
                                    {
                                        d9155rkey_1 = int.Parse(bll9155.FindBySql("SOURCE_PTR=" + d56rkey + " and trantp=1")[0].RKEY.ToString());
                                        d9155info = bll9155.getDATA9155ByRKEY(d9155rkey_1);
                                        //d9155info.QUAN_BACKLOG = d9155info.QUAN_BACKLOG - QTY_BACKLOG < 0 ? 0 : d9155info.QUAN_BACKLOG - QTY_BACKLOG;
                                        //d9155info.FQUAN_BACKLOG = d9155info.FQUAN_BACKLOG - FQUAN_BACKLOG < 0 ? 0 : d9155info.FQUAN_BACKLOG - FQUAN_BACKLOG;
                                        //d9155info.SQUAN_BACKLOG = d9155info.SQUAN_BACKLOG - SQUAN_BACKLOG < 0 ? 0 : d9155info.SQUAN_BACKLOG - SQUAN_BACKLOG;
                                        d9155info.QUAN_PROD = d9155info.QUAN_PROD + QTY_BACKLOG;
                                        d9155info.FQUAN_PROD = d9155info.FQUAN_PROD + FQUAN_BACKLOG;
                                        d9155info.SQUAN_PROD = d9155info.SQUAN_PROD + SQUAN_BACKLOG;
                                        bll9155.Update(cmd, conn, trans, d9155info);
                                    }


                                    #endregion

                                    #region DATA0048 D9155
                                    ///DATA0048
                                    ///
                                    int d48rkey_1 = 0;
                                    d48info.WO_PTR = IntD06Rkey;
                                    d48info.TPUT_PTR = d56rkey;
                                    d48info.PART_BATCH_PTR = 0;
                                    d48info.TDATE = Func.GetNowDate();
                                    d48info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                    d48info.QTY_PROD = QTY_BACKLOG;
                                    d48info.QTY_REJECT = 0;
                                    d48info.WORK_CENTER_PTR = WC_PTR;
                                    d48info.COSTED_FLAG = "N";
                                    d48info.REFERENCE_NUMBER = "";
                                    d48info.KEYPAD_ID = "0";
                                    d48info.QTY_INSP = QTY_BACKLOG;
                                    d48info.WIP_APPROVAL_FLAG = 0;
                                    d48rkey_1 = bll48.Add(cmd, conn, trans, d48info);

                                    ///DATA9155
                                    ///
                                    d9155info.TRANTP = 2;
                                    d9155info.SOURCE_PTR = d48rkey_1;
                                    d9155info.FQUAN_BACKLOG = 0;
                                    d9155info.SQUAN_BACKLOG = 0;
                                    d9155info.QUAN_BACKLOG = 0;
                                    d9155info.FQUAN_PHYBACKLOG = 0;
                                    d9155info.SQUAN_PHYBACKLOG = 0;
                                    d9155info.QUAN_PHYBACKLOG = 0;
                                    d9155info.FQUAN_PROD = FQUAN_BACKLOG;
                                    d9155info.SQUAN_PROD = SQUAN_BACKLOG;
                                    d9155info.QUAN_PROD = QTY_BACKLOG;
                                    d9155info.FQUAN_REJ = 0;
                                    d9155info.SQUAN_REJ = 0;
                                    d9155info.QUAN_REJ = 0;
                                    d9155info.FQUAN_REVIEW = 0;
                                    d9155info.SQUAN_REVIEW = 0;
                                    d9155info.QUAN_REVIEW = 0;
                                    d9155info.FQUAN_ALLOC = 0;
                                    d9155info.SQUAN_ALLOC = 0;
                                    d9155info.QUAN_ALLOC = 0;
                                    bll9155.Add(cmd, conn, trans, d9155info);



                                    #endregion

                                    #region DATA057 D9155

                                    ///DATA0057
                                    ///
                                    int d57rkey = 0;
                                    d57info.W_C_PTR = WC_PTR;
                                    d57info.TPUT_PTR = d56rkey;
                                    d57info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                    d57info.EMPL_PTR = FUNC.GlobalVal.UserInfo.DATA0005RKEY;
                                    d57info.QTY_PROD = QTY_BACKLOG;
                                    d57info.TDATE = Func.GetNowDate();
                                    d57info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                    d57info.TRAN_PTR = d48rkey_1;
                                    d57rkey = bll57.Add(cmd, conn, trans, d57info);



                                    #endregion

                                }

                                #region 下一过数点 DATA0056 D9155
                                ///DATA0056
                                ///
                                int d56rkey_02 = 0;

                                d56rkey_02 = int.Parse(bll56.FindBySql("WO_PTR=" + IntD06Rkey + " and STEP=" + next_step)[0].RKEY.ToString());
                                d56info = bll56.getDATA0056ByRKEY(d56rkey_02);
                                d56info.QTY_BACKLOG = d56info.QTY_BACKLOG + QTY_BACKLOG;
                                bll56.Update(cmd, conn, trans, d56info);

                                if (Switch_grant == true)
                                {
                                    if (bll9139.FindBySql("DATA0056_PTR=" + d56rkey_02.ToString()).Count > 0)
                                    {
                                        int d9139rkey = (int)bll9139.FindBySql("DATA0056_PTR=" + d56rkey_02.ToString())[0].RKEY;
                                        d9139info = bll9139.getDATA9139ByRKEY(d9139rkey);
                                        d9139info.PHY_QTY_BACKLOG = d9139info.PHY_QTY_BACKLOG + QTY_BACKLOG;
                                        bll9139.Update(cmd, conn, trans, d9139info);

                                    }
                                    else
                                    {
                                        d9139info.DATA0056_PTR = d56rkey_02;
                                        d9139info.PHY_QTY_BACKLOG = QTY_BACKLOG;
                                        bll9139.Add(cmd, conn, trans, d9139info);
                                    }


                                }

                                ///DATA9155
                                ///
                                int d9155rkey_2 = 0;
                                if (bll9155.FindBySql("SOURCE_PTR=" + d56rkey_02 + " and trantp=1").Count > 0)
                                {
                                    d9155rkey_2 = int.Parse(bll9155.FindBySql("SOURCE_PTR=" + d56rkey_02 + " and trantp=1")[0].RKEY.ToString());
                                    d9155info = bll9155.getDATA9155ByRKEY(d9155rkey_2);
                                    d9155info.QUAN_BACKLOG = d9155info.QUAN_BACKLOG + QTY_BACKLOG;
                                    d9155info.FQUAN_BACKLOG = d9155info.FQUAN_BACKLOG + FQUAN_BACKLOG;
                                    d9155info.SQUAN_BACKLOG = d9155info.SQUAN_BACKLOG + SQUAN_BACKLOG;
                                    if (Switch_grant == true)
                                    {
                                        d9155info.QUAN_PHYBACKLOG = d9155info.QUAN_PHYBACKLOG + QTY_BACKLOG;
                                        d9155info.FQUAN_PHYBACKLOG = d9155info.FQUAN_PHYBACKLOG + FQUAN_BACKLOG;
                                        d9155info.SQUAN_PHYBACKLOG = d9155info.SQUAN_PHYBACKLOG + SQUAN_BACKLOG;
                                    }

                                    bll9155.Update(cmd, conn, trans, d9155info);
                                }
                                #endregion

                            }
                            #endregion

                            #region 过数点中间不存在过数流程
                            else
                            {

                                #region 下一过数点 DATA0056 D9155
                                ///DATA0056
                                ///
                                int d56rkey_03 = 0;
                                d56rkey_03 = int.Parse(bll56.FindBySql("WO_PTR=" + IntD06Rkey + " and STEP=" + next_step)[0].RKEY.ToString());
                                d56info = bll56.getDATA0056ByRKEY(d56rkey_03);
                                d56info.QTY_BACKLOG = d56info.QTY_BACKLOG + QTY_BACKLOG;
                                bll56.Update(cmd, conn, trans, d56info);

                                if (Switch_grant == true)
                                {
                                    if (bll9139.FindBySql("DATA0056_PTR=" + d56rkey_03.ToString()).Count > 0)
                                    {
                                        int d9139rkey = (int)bll9139.FindBySql("DATA0056_PTR=" + d56rkey_03.ToString())[0].RKEY;
                                        d9139info = bll9139.getDATA9139ByRKEY(d9139rkey);
                                        d9139info.PHY_QTY_BACKLOG = d9139info.PHY_QTY_BACKLOG + QTY_BACKLOG;
                                        bll9139.Update(cmd, conn, trans, d9139info);

                                    }
                                    else
                                    {
                                        d9139info.DATA0056_PTR = d56rkey_03;
                                        d9139info.PHY_QTY_BACKLOG = QTY_BACKLOG;
                                        bll9139.Add(cmd, conn, trans, d9139info);
                                    }
                                }
                                ///DATA9155
                                ///
                                if (bll9155.FindBySql("SOURCE_PTR=" + d56rkey_03 + " and trantp=1").Count > 0)
                                {
                                    int d9155rkey_3 = 0;
                                    d9155rkey_3 = int.Parse(bll9155.FindBySql("SOURCE_PTR=" + d56rkey_03 + " and trantp=1")[0].RKEY.ToString());
                                    d9155info = bll9155.getDATA9155ByRKEY(d9155rkey_3);
                                    d9155info.QUAN_BACKLOG = d9155info.QUAN_BACKLOG + QTY_BACKLOG;
                                    d9155info.FQUAN_BACKLOG = d9155info.FQUAN_BACKLOG + FQUAN_BACKLOG;
                                    d9155info.SQUAN_BACKLOG = d9155info.SQUAN_BACKLOG + SQUAN_BACKLOG;

                                    if (Switch_grant == true)
                                    {
                                        d9155info.QUAN_PHYBACKLOG = d9155info.QUAN_PHYBACKLOG + QTY_BACKLOG;
                                        d9155info.FQUAN_PHYBACKLOG = d9155info.FQUAN_PHYBACKLOG + FQUAN_BACKLOG;
                                        d9155info.SQUAN_PHYBACKLOG = d9155info.SQUAN_PHYBACKLOG + SQUAN_BACKLOG;
                                    }
                                    bll9155.Update(cmd, conn, trans, d9155info);
                                }


                                #endregion

                            }
                            #endregion


                            #endregion


                            trans.Commit();
                            //this.Close();
                            // MessageBox.Show("数据处理完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = 1;
                        }
                        catch (Exception ee)
                        {
                            //img = "E";
                            trans.Rollback();//异常回滚
                            log.PrintInfo(ee);
                            MessageBox.Show("数据处理失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


            }
            return returnValue;
        }

        #endregion


        #region  报废
        /// <summary>
        /// 报废
        /// </summary>
        /// <param name="step"></param>
        /// <param name="next_step"></param>
        private int Date_processing_Reject(decimal woPtr, decimal stepNumber, decimal deptPtr, decimal unitPtr, List<string> list)
        {
            int returnValue = 0;
            Switch_grant = Func.HasSwitch(5);

            int partPanle = 1;
            int partSet = 1;

            

            #region 数据类及变量初始化
            
            string Hold = "N";
            //D0440BLL bll440 = new D0440BLL(db);
            DATA0038BLL bll38 = new DATA0038BLL(db);
            DATA0034BLL bll34 = new DATA0034BLL(db);
            DATA0056 d56info = new DATA0056();
            DATA0056BLL bll56 = new DATA0056BLL(db);
            DATA0048 d48info = new DATA0048();
            DATA0048BLL bll48 = new DATA0048BLL(db);
            DATA0057 d57info = new DATA0057();
            DATA0057BLL bll57 = new DATA0057BLL(db);
            DATA0058 d58info = new DATA0058();
            DATA0058BLL bll58 = new DATA0058BLL(db);
            DATA0505 d505info = new DATA0505();
            DATA0505BLL bll505 = new DATA0505BLL(db);
            DATA0553 d553info = new DATA0553();
            DATA0553BLL bll553 = new DATA0553BLL(db);
            DATA9155 d9155info = new DATA9155();
            DATA9155BLL bll9155 = new DATA9155BLL(db);
            DATA0006 d06info = new DATA0006();
            DATA0006BLL bll06 = new DATA0006BLL(db);
            DATA0053 d53info = new DATA0053();
            DATA0053BLL bll53 = new DATA0053BLL(db);
            DATA0050 d50info = new DATA0050();
            DATA0050BLL bll50 = new DATA0050BLL(db);
            DATA0113 d113info = new DATA0113();
            DATA0113BLL bll113 = new DATA0113BLL(db);

            DATA9139 d9139info = new DATA9139();
            DATA9139BLL bll9139 = new DATA9139BLL(db);

            DATA0117 d117info = new DATA0117();
            DATA0117BLL bll117 = new DATA0117BLL(db);

            DATA0011 d11info = new DATA0011();
            DATA0011BLL bll11 = new DATA0011BLL(db);

            DATA0002 d02info = new DATA0002();
            DATA0002BLL d02bll = new DATA0002BLL(db);

            DATA0047 d47info = new DATA0047();
            DATA0047BLL bll47 = new DATA0047BLL(db);

            DATA0506 d506info = new DATA0506();
            DATA0506BLL bll506 = new DATA0506BLL(db);

            #endregion

            int D34RKEY1 = int.Parse(bll38.FindBySql("SOURCE_PTR=" + woPtr + " and TTYPE=2 and STEP_NUMBER=" + stepNumber.ToString())[0].DEPT_PTR.ToString());
                if (bll34.getDATA0034ByRKEY(D34RKEY1).TTYPE != "1")
                {
                    D34RKEY1 = (int)bll34.getDATA0034ByRKEY(D34RKEY1).DEPT_PTR;
                }
                int d56key = (int)bll56.FindBySql("WO_PTR=" + woPtr + " and step=" + stepNumber)[0].RKEY; ;

                int IntDeptRkey = int.Parse(bll34.FindBySql("DEPT_PTR=" + D34RKEY1 + " and TTYPE=3")[0].RKEY.ToString());

                partPanle = (int)bll06.getDATA0006ByRKEY(woPtr).PARTS_PER_PANEL;
                IList<DATA0002>  d02list = d02bll.FindBySql("UNIT_TYPE ='Y'");
              if (d02list.Count > 0)
              {

                  d47info = bll47.FindBySql("UNIT_POINTER=" + d02list[0].RKEY.ToString() + " and TTYPE=2   and SOURCE_POINTER=" + bll06.getDATA0006ByRKEY(woPtr).CUST_PART_PTR.ToString())[0];
                  partSet = (int)d47info.UNIT_VALUE;
                 
              }

                using (SqlConnection conn = new SqlConnection(GlobalVal.ConnectionString(GlobalVal.UserInfo.FactoryID)))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction(IsolationLevel.ReadCommitted))
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 360;
                        try
                        {

                            foreach (string str in list)
                            {
                                #region 数量
                                int qty=int.Parse(str.Split(',')[0].ToString());
                                int d39keky = int.Parse(str.Split(',')[1].ToString());
                                int qtyPanel = 0;
                                int qtySet = 0;
                                int qtyPcs = 0;

                                if (unitPtr == 1)
                                {
                                    qtyPcs = qty;
                                    qtyPanel = (int)Math.Ceiling(double.Parse(qty.ToString()) / double.Parse(partPanle.ToString()));
                                    qtySet = (int)Math.Ceiling(double.Parse(qty.ToString()) / double.Parse(partSet.ToString()));

                                }
                                else if (unitPtr == 4)
                                {
                                    qtyPanel = qty;
                                    qtyPcs = qty*partPanle;
                                    qtySet = (int)Math.Ceiling(double.Parse(qtyPcs.ToString()) / double.Parse(partSet.ToString()));
                                }
                                else
                                {
                                    qtyPcs = qty*partSet;
                                    qtyPanel = (int)Math.Ceiling(double.Parse(qtyPcs.ToString()) / double.Parse(partPanle.ToString()));
                                    qtySet = qty;
                                }
                                #endregion


                                #region DATA0048(插入本站记录)
                                ///DATA0048(插入本站记录)
                                ///
                                int d48rkey = 0;
                                d48info.WO_PTR = woPtr;
                                d48info.TPUT_PTR = d56key;
                                d48info.PART_BATCH_PTR = 0;
                                d48info.TDATE = Func.GetNowDate();
                                d48info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                d48info.QTY_PROD = 0;
                                d48info.QTY_REJECT = 0;
                                d48info.WORK_CENTER_PTR = IntDeptRkey;
                                d48info.COSTED_FLAG = "N";
                                d48info.REFERENCE_NUMBER = "";
                                d48info.KEYPAD_ID = "0";
                                d48info.QTY_INSP = 0;
                                //if (WIP_APPROVAL_FLAG == 1)
                                //    d48info.WIP_APPROVAL_FLAG = 1;
                                //else
                                d48info.WIP_APPROVAL_FLAG = 0;
                                d48rkey = bll48.Add(cmd, conn, trans, d48info);

                                ///DATA9155
                                ///
                                d9155info.TRANTP = 2;
                                d9155info.SOURCE_PTR = d48rkey;
                                d9155info.FQUAN_BACKLOG = 0;
                                d9155info.SQUAN_BACKLOG = 0;
                                d9155info.QUAN_BACKLOG = 0;
                                d9155info.FQUAN_PHYBACKLOG = 0;
                                d9155info.SQUAN_PHYBACKLOG = 0;
                                d9155info.QUAN_PHYBACKLOG = 0;
                                d9155info.FQUAN_PROD = 0;
                                d9155info.SQUAN_PROD = 0;
                                d9155info.QUAN_PROD = 0;
                                d9155info.FQUAN_REJ = 0;
                                d9155info.SQUAN_REJ = 0;
                                d9155info.QUAN_REJ = 0;
                                d9155info.FQUAN_REVIEW = 0;
                                d9155info.SQUAN_REVIEW = 0;
                                d9155info.QUAN_REVIEW = 0;
                                d9155info.FQUAN_ALLOC = 0;
                                d9155info.SQUAN_ALLOC = 0;
                                d9155info.QUAN_ALLOC = 0;
                                bll9155.Add(cmd, conn, trans, d9155info);


                                d9155info.TRANTP = 9;
                                d9155info.SOURCE_PTR = d48rkey;
                                d9155info.FQUAN_BACKLOG = 0;
                                d9155info.SQUAN_BACKLOG = 0;
                                d9155info.QUAN_BACKLOG = 0;
                                d9155info.FQUAN_PHYBACKLOG = 0;
                                d9155info.SQUAN_PHYBACKLOG = 0;
                                d9155info.QUAN_PHYBACKLOG = 0;
                                d9155info.FQUAN_PROD = 0;
                                d9155info.SQUAN_PROD = 0;
                                d9155info.QUAN_PROD = 0;
                                d9155info.FQUAN_REJ = 0;
                                d9155info.SQUAN_REJ = 0;
                                d9155info.QUAN_REJ = 0;
                                d9155info.FQUAN_REVIEW = qtyPanel;
                                d9155info.SQUAN_REVIEW = qtySet;
                                d9155info.QUAN_REVIEW = qtyPcs;
                                d9155info.FQUAN_ALLOC = 0;
                                d9155info.SQUAN_ALLOC = 0;
                                d9155info.QUAN_ALLOC = 0;
                                bll9155.Add(cmd, conn, trans, d9155info);

                                #endregion



                                #region 若填写待检数量则插入DATA0505
                               
                                    int d505key = 0;
                                    d505info.DATA0056_PTR = d56key;
                                    d505info.DATA0034_PTR = IntDeptRkey;
                                    d505info.WO_PTR = woPtr;
                                    d505info.STEP_NO = stepNumber;
                                    d505info.CUST_PART_PTR = bll06.getDATA0006ByRKEY(woPtr).CUST_PART_PTR;
                                    d505info.INVENTORY_PART_PTR = bll06.getDATA0006ByRKEY(woPtr).INVENTORY_PTR;
                                    d505info.DATA0048_PTR = d48rkey;
                                    d505info.QTY_TO_BE_REVIEWED = qtyPcs;
                                    d505info.QTY_REJECTED = 0;
                                    d505info.QTY_RETURNED = 0;
                                    d505info.EMPL_PTR = GlobalVal.UserInfo.DATA0005RKEY;
                                    d505info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                    d505info.TRANS_DATE_TIME = Func.GetNowDate();
                                    d505info.QTY_PRB_PANELS = qtyPanel;
                                    d505info.QTY_RETURN_PANELS = 0;
                                    d505info.QTY_DEFECTED = 0;
                                    d505key = bll505.Add(cmd, conn, trans, d505info);




                             

                                #endregion


                                #region Update data0505
                                    d505info = bll505.getDATA0505ByRKEY(d505key);
                                d505info.QTY_TO_BE_REVIEWED = 0;
                                d505info.QTY_PRB_PANELS =0;
                                d505info.QTY_REJECTED =qtyPcs;
                                d505info.QTY_RETURNED = 0;
                                d505info.QTY_RETURN_PANELS = qtyPanel;
                                d505info.QTY_DEFECTED = qtyPcs;
                                bll505.Update(cmd, conn, trans, d505info);

                                #endregion

                                #region Update data0056/data9155

                                d56info = bll56.getDATA0056ByRKEY(d505info.DATA0056_PTR);
                                //d06rkey = Convert.ToInt32(d56info.WO_PTR);
                                d56info.QTY_REJECTED = d56info.QTY_REJECTED + qtyPcs;//Convert.ToInt32(txt_rej_pcs.Text.ToString());
                                d56info.QTY_REJ_PANELS = d56info.QTY_REJ_PANELS + qtyPanel;//Convert.ToInt32(txt_rej_pnl.Text.ToString());
                                d56info.QTY_BACKLOG = d56info.QTY_BACKLOG - qtyPcs > 0 ? d56info.QTY_BACKLOG - qtyPcs : 0;
                                bll56.Update(cmd, conn, trans, d56info);

                                if (bll9155.FindBySql("SOURCE_PTR=" + d505info.DATA0056_PTR.ToString() + " AND TRANTP=1").Count > 0)
                                {
                                    int d9155rkey = Convert.ToInt32(bll9155.FindBySql("SOURCE_PTR=" + d505info.DATA0056_PTR.ToString() + " AND TRANTP=1")[0].RKEY);
                                    d9155info = bll9155.getDATA9155ByRKEY(d9155rkey);
                                    d9155info.FQUAN_REJ = d9155info.FQUAN_REJ + qtyPanel;// Convert.ToInt32(txt_rej_pnl.Text.ToString());
                                    d9155info.SQUAN_REJ = d9155info.SQUAN_REJ + qtySet;// Convert.ToInt32(txt_rej_strip.Text.ToString());
                                    d9155info.QUAN_REJ = d9155info.QUAN_REJ + qtyPcs;//Convert.ToInt32(txt_rej_pcs.Text.ToString());
                                    d9155info.FQUAN_BACKLOG = d9155info.FQUAN_BACKLOG - qtyPanel > 0 ? d9155info.FQUAN_BACKLOG - qtyPanel : 0;
                                    d9155info.SQUAN_BACKLOG = d9155info.SQUAN_BACKLOG - qtySet > 0 ? d9155info.SQUAN_BACKLOG - qtySet : 0;
                                    d9155info.QUAN_BACKLOG = d9155info.QUAN_BACKLOG - qtyPcs > 0 ? d9155info.QUAN_BACKLOG - qtyPcs : 0;
                                    if (Switch_grant == true)
                                    {
                                        d9155info.FQUAN_PHYBACKLOG = d9155info.FQUAN_PHYBACKLOG - qtyPanel > 0 ? d9155info.FQUAN_PHYBACKLOG - qtyPanel : 0;
                                        d9155info.SQUAN_PHYBACKLOG = d9155info.SQUAN_PHYBACKLOG - qtySet > 0 ? d9155info.SQUAN_PHYBACKLOG - qtySet : 0;
                                        d9155info.QUAN_PHYBACKLOG = d9155info.QUAN_PHYBACKLOG - qtyPcs > 0 ? d9155info.QUAN_PHYBACKLOG - qtyPcs : 0;
                                    }
                                    bll9155.Update(cmd, conn, trans, d9155info);
                                }

                                if (bll9139.FindBySql("DATA0056_PTR=" + d56info.RKEY.ToString()).Count > 0)
                                {

                                    int D9139KEY = (int)bll9139.FindBySql("DATA0056_PTR=" + d56info.RKEY.ToString())[0].RKEY;
                                    d9139info = bll9139.getDATA9139ByRKEY(D9139KEY);
                                    d9139info.PHY_QTY_BACKLOG = d9139info.PHY_QTY_BACKLOG - qtyPcs > 0 ? d9139info.PHY_QTY_BACKLOG - qtyPcs : 0;
                                    bll9139.Update(cmd, conn, trans, d9139info);
                                }

                                #endregion

                                #region Update data0048/data9155

                                d48info = bll48.getDATA0048ByRKEY(d505info.DATA0048_PTR);
                                d48info.QTY_REJECT =qtyPcs;
                                bll48.Update(cmd, conn, trans, d48info);

                                if (bll9155.FindBySql("SOURCE_PTR=" + d505info.DATA0048_PTR.ToString() + " AND TRANTP=2").Count > 0)
                                {
                                    int d9155rkey = Convert.ToInt32(bll9155.FindBySql("SOURCE_PTR=" + d505info.DATA0048_PTR.ToString() + " AND TRANTP=2")[0].RKEY);
                                    d9155info = bll9155.getDATA9155ByRKEY(d9155rkey);
                                    d9155info.FQUAN_REJ =qtyPanel;
                                    d9155info.SQUAN_REJ = qtySet;
                                    d9155info.QUAN_REJ = qtyPcs;
                                    bll9155.Update(cmd, conn, trans, d9155info);
                                }
                                #endregion

                                #region Update data0006

                                d06info = bll06.getDATA0006ByRKEY(woPtr);
                                d06info.QUAN_REJ = d06info.QUAN_REJ + qtyPcs;
                                if (Switch_grant == false)
                                {
                                    if (d06info.QUAN_REJ + d06info.QUAN_PROD == d06info.QUAN_SCH)
                                    {
                                        d06info.PROD_STATUS = 5;
                                    }
                                    else
                                    {
                                        d06info.PROD_STATUS = 3;
                                    }
                                }
                                else
                                {
                                    string sql = string.Format(@"select cast(SUM(data9139.PHY_QTY_BACKLOG) as int) qty from data9139 with(nolock) 
                                                        left join data0056 with(nolock) on data9139.DATA0056_PTR=data0056.RKEY
                                                        where data0056.WO_PTR={0}", woPtr);

                                    DataTable dt1 = new DataTable();
                                    dt1 = db.GetDataSet(sql);
                                    if (dt1.Rows.Count > 0)
                                    {
                                        if (int.Parse(dt1.Rows[0][0].ToString()) > 0)
                                        {
                                            d06info.PROD_STATUS = 3;
                                        }
                                        else
                                        {

                                            d06info.PROD_STATUS = 5;

                                        }
                                    }
                                }
                                bll06.Update(cmd, conn, trans, d06info);

                                if (bll9155.FindBySql("SOURCE_PTR=" + woPtr.ToString() + " AND TRANTP=3").Count > 0)
                                {
                                    int D9155KEY = (int)bll9155.FindBySql("SOURCE_PTR=" + woPtr.ToString() + " AND TRANTP=3")[0].RKEY;
                                    d9155info = bll9155.getDATA9155ByRKEY(D9155KEY);
                                    d9155info.FQUAN_REJ = d9155info.FQUAN_REJ +qtyPanel;
                                    d9155info.SQUAN_REJ = d9155info.SQUAN_REJ + qtySet;
                                    d9155info.QUAN_REJ = d9155info.QUAN_REJ +qtyPcs;
                                    bll9155.Update(cmd, conn, trans, d9155info);
                                }

                                #endregion


                                #region Insert into data0058/9155

                                #region 分配报废
                             

                                   
                                        #region Insert data0058
                                        int d58rkey = 0;
                                        d58info.W_C_PTR = deptPtr;
                                        d58info.TPUT_PTR = d505info.DATA0056_PTR;
                                        d58info.REJECT_PTR =d39keky;
                                        d58info.USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                        d58info.EMPL_PTR = GlobalVal.UserInfo.DATA0005RKEY;
                                        d58info.QTY_REJECT = qtyPcs;
                                        d58info.REJ_VALUE = 0;
                                        d58info.TDATE = DateTime.Parse(Func.GetNowDate().ToShortDateString());
                                        d58info.TTIME = int.Parse(Func.GetNowDate().ToString("HHmmss"));
                                        d58info.TRAN_PTR = d505info.DATA0048_PTR;
                                        d58info.ADJ_W_C_PTR = deptPtr;
                                        d58info.ADJ_QTY_REJECT = qtyPcs;
                                        d58info.ADJ_REJ_VALUE = 0;
                                        d58info.ADJ_USER_PTR = GlobalVal.UserInfo.DATA0073RKEY;
                                        d58rkey = bll58.Add(cmd, conn, trans, d58info);
                                        #endregion

                                        #region Insert into data9155
                                        d9155info.TRANTP = 11;
                                        d9155info.SOURCE_PTR = d58rkey;
                                       
                                     
                                        d9155info.FQUAN_REJ =qtyPanel;
                                        d9155info.SQUAN_REJ =qtySet;
                                        d9155info.QUAN_REJ = qtyPcs;
                                        
                                        d9155info.QUAN_BACKLOG = 0;
                                        d9155info.FQUAN_BACKLOG = 0;
                                        d9155info.SQUAN_BACKLOG = 0;
                                        d9155info.FQUAN_PROD = 0;
                                        d9155info.SQUAN_PROD = 0;
                                        d9155info.QUAN_PROD = 0;
                                        d9155info.FQUAN_REVIEW = 0;
                                        d9155info.SQUAN_REVIEW = 0;
                                        d9155info.QUAN_REVIEW = 0;
                                        bll9155.Add(cmd, conn, trans, d9155info);



                                        #endregion

                                  

                              


                                        #region Insert into data0506
                                        d506info.DATA0058_PTR = d58rkey;
                                        d506info.DATA0505_PTR = d505info.RKEY;
                                        d506info.DATA0048_PTR = d505info.DATA0048_PTR;
                                        bll506.Add(cmd, conn, trans, d506info);
                                        #endregion


                                


                                    

                                
                                #endregion


                              
                                #endregion

                            }


                            trans.Commit();
                            //this.Close();
                            // MessageBox.Show("数据处理完成！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            returnValue = 1;
                        }
                        catch (Exception ee)
                        {
                            //img = "E";
                            trans.Rollback();//异常回滚
                            log.PrintInfo(ee);
                            MessageBox.Show("数据处理失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }


            
            return returnValue;
        }

        #endregion
    }
}
