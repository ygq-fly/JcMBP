using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
namespace CustomControls
{
    public partial class PowerProgramBar : UserControl
    {
        #region 字段
        /// <summary>
        /// 最小值
        /// </summary>
        float _MinValue;
        /// <summary>
        /// 最大值
        /// </summary>
        float _MaxValue;
        /// <summary>
        /// 当前值
        /// </summary>
        float _Value;
        /// <summary>
        /// 进度条背景
        /// </summary>
        LinearGradientBrush _ProgramBarBackGround;
        /// <summary>
        /// 进度条前景
        /// </summary>
        LinearGradientBrush _ProgramBarForeGround;
        /// <summary>
        /// 刻度颜色
        /// </summary>
        Color _GraduationColor;
        /// <summary>
        /// 刻度文本颜色
        /// </summary>
        Color _GraduationTextColor;
        /// <summary>
        /// 刻度段数
        /// </summary>
        int _GraduationNumber;
        /// <summary>
        /// 实际值
        /// </summary>
        private float _RealValue;

        #endregion

        #region 属性
        /// <summary>
        /// 最大值
        /// </summary>
        public float MaxValue
        {
            get
            {
                return _MaxValue;
            }
            set
            {
                _MaxValue = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// 最小值
        /// </summary>
        public float MinValue
        {
            get
            {
                return _MinValue;
            }
            set
            {
                _MinValue = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// 当前值
        /// </summary>
        public float Value
        {
            get
            {
                return _Value;
            }
            set
            {
                _Value = value;
                this.Invalidate();
                //if (value >= _MinValue && value <= _MaxValue)
                //{
                //    _Value = value;
                //    this.Invalidate();
                //}
            }
        }
        /// <summary>
        /// 进度条背景
        /// </summary>
        public LinearGradientBrush ProgramBarBackGround
        {
            get
            {
                return _ProgramBarBackGround;
            }
            set
            {
                _ProgramBarBackGround = value;
            }
        }
        /// <summary>
        /// 进度条前景
        /// </summary>
        public LinearGradientBrush ProgramBarForeGround
        {
            get
            {
                return _ProgramBarForeGround;
            }
            set
            {
                _ProgramBarForeGround = value;
            }
        }
        /// <summary>
        /// 刻度颜色
        /// </summary>
        public Color GraduationColor
        {
            get
            {
                return _GraduationColor;
            }
            set
            {
                _GraduationColor = value;
            }
        }
        /// <summary>
        /// 刻度文本颜色
        /// </summary>
        public Color GraduationTextColor
        {
            get
            {
                return _GraduationTextColor;
            }
            set
            {
                _GraduationTextColor = value;
            }
        }
        /// <summary>
        /// 刻度段数
        /// </summary>
        public int GraduationNumber
        {
            get
            {
                return _GraduationNumber;
            }
            set
            {
                _GraduationNumber = value;
            }
        }

        /// <summary>
        /// 实际值
        /// </summary>
        public float RealValue
        {
            get { return _RealValue; }
            set 
            { 
                _RealValue = value; 
                this.Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public PowerProgramBar()
        {
            InitializeComponent();
            _GraduationNumber = 10;
            _MinValue = 0;
            _MaxValue = 100;
            _Value = 50;
            _ProgramBarBackGround = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(247, 49, 50), Color.FromArgb(247, 49, 50), LinearGradientMode.Horizontal);
            _ProgramBarForeGround = new LinearGradientBrush(this.ClientRectangle, Color.FromArgb(117, 183, 75), Color.FromArgb(117, 183, 75), LinearGradientMode.Horizontal);
            _GraduationColor = Color.FromArgb(148, 148, 148);
            //_GraduationTextColor = Color.FromArgb(148, 148, 148);
            _GraduationTextColor = Color.White;
        }

        #region 实现
        /// <summary>
        /// 控件重绘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PowerProgramBar_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                //this.SetStyle(ControlStyles.UserPaint, true);
                //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                //this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

                Bitmap bmp = new Bitmap(e.ClipRectangle.Width,e.ClipRectangle.Height);
                Graphics gBmp = Graphics.FromImage(bmp);
                //获得有效绘制区域
                Rectangle rc = e.ClipRectangle;
                //区域划分
                    //刻度区
                Rectangle rcKeDu = new Rectangle(new Point(0,8), new Size(48, rc.Height-16));
                    //进度区
                Rectangle rcJinDu = new Rectangle(48, 8, rc.Width - 48, rc.Height-16);
                float hk = (float)(_Value-_MinValue)/(_MaxValue-_MinValue);
                int JinDuForeHeight = (int)(rcJinDu.Height * hk);
                Rectangle rcJinDuFore = new Rectangle(48, rcJinDu.Height - JinDuForeHeight + 8, rcJinDu.Width, JinDuForeHeight);
                //绘制操作
                    //绘制刻度
                float KeDuK =  (float)(_MaxValue - _MinValue)/_GraduationNumber;
                float[] KeDuZT = new float[_GraduationNumber+1];
                KeDuZT[0] = _MinValue;
                KeDuZT[_GraduationNumber] = _MaxValue;
                for (int i = 1; i < _GraduationNumber;i++)
                {
                    KeDuZT[i] = (int)(i*KeDuK)+_MinValue;
                }
                float JinDuSK = (float)rcKeDu.Height / (5*_GraduationNumber);
                for (int i = 0,ofk = 5; i <= 5*_GraduationNumber;i++)
                {
                    ofk = 5;
                    if (i%5==0)
                    {
                        ofk = 8;
                        gBmp.DrawString(KeDuZT[i / 5].ToString(),this.Font, new SolidBrush(_GraduationTextColor), 2, (float)(-JinDuSK * i + rcKeDu.Height));
                    }
                    gBmp.DrawLine(new Pen(_GraduationColor, 1), new Point(rcKeDu.Right - ofk, (int)(-JinDuSK * i + rcKeDu.Height + 8)), new Point(rcKeDu.Right, (int)(-JinDuSK * i + rcKeDu.Height + 8)));
                }
                    //绘制进度条
                        //绘制颜色
                _ProgramBarBackGround = new LinearGradientBrush(rcJinDu, Color.FromArgb(247, 49, 50), Color.FromArgb(247, 49, 50), LinearGradientMode.Horizontal);
                _ProgramBarForeGround = new LinearGradientBrush(rcJinDuFore, Color.FromArgb(117, 183, 75), Color.FromArgb(117, 183, 75), LinearGradientMode.Horizontal);
                gBmp.FillRectangle(_ProgramBarBackGround, rcJinDu);
                gBmp.FillRectangle(_ProgramBarForeGround, rcJinDuFore);
                gBmp.DrawRectangle(new Pen(Brushes.Transparent, 3), rcJinDu);
                //绘制真实值
                float fk = rcJinDu.Height / (MaxValue - MinValue);

             //   System.Diagnostics.Trace.WriteLine(RealValue);
             //   System.Diagnostics.Trace.WriteLine((RealValue - MinValue) * fk);
             //   System.Diagnostics.Trace.WriteLine((int)(rcJinDu.Bottom - (RealValue - MinValue) * fk));
                gBmp.DrawLine(Pens.Black, new Point(rcJinDu.Left, (int)(rcJinDu.Bottom - (RealValue - MinValue) * fk)), new Point(rcJinDu.Right, (int)(rcJinDu.Bottom - (RealValue - MinValue) * fk)));
                //复制双缓存
                e.Graphics.DrawImage(bmp,0,0);
            }
            catch (System.Exception ex)
            {
                Console.Write(ex.Message);
            }

        }
       #endregion

      
    }
}
