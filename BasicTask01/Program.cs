using System;

namespace BasicTask01
{
    /**************************************************************************************************/
    /*  実施日 |                                                                                      */
    /* -----------------------------------------------------------------------------------------------*/
    /*  実施者 |                                                                                      */
    /* -----------------------------------------------------------------------------------------------*/
    /*  確認者 |                                                                                      */
    /**************************************************************************************************/

    /* 課題開始前に、必ずREADME.txtを一読してから、課題を開始してください。 */
    /* 課題が完成した場合は、以下の観点で入力を行い、値が表示されるか確認してください。 */
    /* DateTimeのParse処理等を利用することで簡単に入力日付を比較することができますが、今回は使用せず、あくまで入力値を使用して、経過日数を求めてください。 */

    // 1.閏年の場合に計算結果が正しいかどうか。
    // 2.誕生日に2018/12/31を、指定日付に2019/1/1を入力した場合に、正しい値が出力されるかどうか。
    // 3.誕生日と指定日付を同日にして、正しい値が出力されるかどうか。
    // 4.存在日付を入力した場合に、ただしく表示されるかどうか。(32日は存在しないので、存在しない日付が入力された場合は、計算を行わない。)

    /* 上記のテスト確認がとれた状態で、課題を提出してください。 */

    class Program
    {
        /// <summary> 誕生年 </summary>
        private static int byy;
        /// <summary> 誕生月 </summary>
        private static int bmm;
        /// <summary> 誕生日 </summary>
        private static int bdd;

        /// <summary> 指定年 </summary>
        private static int tyy;
        /// <summary> 指定月 </summary>
        private static int tmm;
        /// <summary> 指定日 </summary>
        private static int tdd;

        static void Main(string[] args)
        {
            // プログラムの開始メッセージを表示
            Console.WriteLine("誕生日からの経過日数を計算します。");
            Console.WriteLine("　※数値以外が入力された場合には、0に変換されます。");

            // 誕生日を入力する
            Console.WriteLine("誕生日の年月日を入力してください。");
            Console.Write("年（西暦）：");
            byy = int.TryParse(Console.ReadLine(), out byy) ? byy : 0;
            Console.Write("月　　　　：");
            bmm = int.TryParse(Console.ReadLine(), out bmm) ? bmm : 0;
            Console.Write("日　　　　：");
            bdd = int.TryParse(Console.ReadLine(), out bdd) ? bdd : 0;

            // 指定日付を入力する
            Console.WriteLine("今日の日付を年月日で入力してください。");
            Console.Write("年（西暦）：");
            tyy = int.TryParse(Console.ReadLine(), out tyy) ? tyy : 0;
            Console.Write("月　　　　：");
            tmm = int.TryParse(Console.ReadLine(), out tmm) ? tmm : 0;
            Console.Write("日　　　　：");
            tdd = int.TryParse(Console.ReadLine(), out tdd) ? tdd : 0;



            Console.WriteLine("答えは：{0}", checkAns(byy, bmm, bdd, tyy, tmm, tdd));   // ここに変更を加えないでください。
        }

        /// <summary>
        /// Fairfield公式を利用した検算用メソッドです。
        /// 　※検算用メソッドですので、改修を加えないでください。
        /// </summary>
        /// <param name="byy">誕生年</param>
        /// <param name="bmm">誕生月</param>
        /// <param name="bdd">誕生日</param>
        /// <param name="tyy">指定年</param>
        /// <param name="tmm">指定月</param>
        /// <param name="tdd">指定日</param>
        /// <returns>経過日数</returns>
        private static int checkAns(int byy, int bmm, int bdd, int tyy, int tmm, int tdd)
        {
            if (bmm == 1 || bmm == 2) { byy--; bmm += 12; }
            var bdays = 365 * byy + byy / 4 - byy / 100 + byy / 400 + 306 * (bmm + 1) / 10 - 428 + bdd;

            if (tmm == 1 || tmm == 2) { tyy--; tmm += 12; }
            var tdays = 365 * tyy + tyy / 4 - tyy / 100 + tyy / 400 + 306 * (tmm + 1) / 10 - 428 + tdd;

            return tdays - bdays;
        }
    }
}
