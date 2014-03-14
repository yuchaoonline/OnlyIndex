using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hom_BLL.i_admin
{
    public class Content
    {
        static StringBuilder sb;

        /// <summary>
        /// 模板单项输出
        /// </summary>
        /// <param name="sb">html</param>
        /// <param name="modelType">html输出类别</param>
        /// <param name="dataField">数据字段</param>
        /// <param name="model_title">字段名称</param>
        /// <param name="model_value">默认值</param>
        /// <param name="model_OtherSetting">其他信息css或html属性</param>
        /// <param name="model_alter">提示信息</param>
        public static void model_w(StringBuilder sb, int modelType, string dataField, string model_title, string model_value, string model_OtherSetting, string model_alter)
        {
            switch (model_id)
            {
                //文本框
                case 1:
                    sb.AppendLine("<tr style='height: 28px;'><td style='text-align: right;'>" + name + "：</td><td style='padding-left: 5px;'>");
                    sb.AppendLine(string.Format("<input ID={0} Text={1} style='width:{2};' runat=server></input><span>{3}</span>", cid, defaultT, width, clert));
                    sb.AppendLine("</td></tr>");
                    break;
                //
                case 2:
                    sb.AppendLine("<tr style='height: 28px;'><td style='text-align: right;'>" + name + "：</td><td style='padding-left: 5px;'>");
                    sb.AppendLine(string.Format(@"<input type='text' ID='{0}' Text='{1}' runat='server' style='width: {2};' />
<input type='button' value='选择图片' id='{0}Open' /><span>{2}</span>", cid, defaultT, width, clert));
                    sb.AppendLine("</td></tr>");
                    break;
                case 3:
                    sb.AppendLine();
                    break;
                case 4: sb.AppendLine(); break;
                case 5: sb.AppendLine(); break;
                case 6: sb.AppendLine(); break;
                case 7: sb.AppendLine(); break;
                case 8: sb.AppendLine(); break;
                case 9: sb.AppendLine(); break;
                case 10: sb.AppendLine(); break;
                default: sb.AppendLine(); break;
            }
        }
        /// <summary>
        /// 对于一个分类的内容编辑页的输出（包含多项）
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        public static StringBuilder WriteConItem(string classid)
        {
            sb = new StringBuilder();
            model_w(sb, 1, "kk", "第二", "de", "100px", "asdfasdf");
            model_w(sb, 1, "kk", "第二", "de", "100px", "asdfasdf");
            model_w(sb, 1, "kk", "第二", "de", "500px", "asdfasdf");
            model_w(sb, 1, "kk", "第二", "de", "100px", "asdfasdf");
            model_w(sb, 2, "kk", "图片", "de", "300px", "adsfasdf");

            ///
            return sb;
        }
    }
}
