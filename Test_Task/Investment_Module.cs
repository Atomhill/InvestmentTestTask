using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Test_Task
{
    internal class Investment_Module
    {
        #region Properties
        public DateTime AgreementDate { get; set; }
        public DateTime CalculationDate { get; set; }
        public float X_Invest { get; set; }
        private float r_AnnualReturn;
        public float R_AnnualReturn
        {
            get { return r_AnnualReturn;}
            set { r_AnnualReturn = value / 100;}
        }
        public int N_Years { get; set; }
        #endregion

        #region Constructors
        public Investment_Module()
        {
            AgreementDate = new DateTime(2019, 1, 1);
            CalculationDate = new DateTime(2019, 1, 1);
            X_Invest = 0f;
            R_AnnualReturn = 0f;
            N_Years = 0;
        }

        public Investment_Module(DateTime startDate, DateTime calculationDate, float invest,
            float aReturn, int years)
        {
            AgreementDate = startDate;
            CalculationDate = calculationDate;
            X_Invest = invest;
            R_AnnualReturn = aReturn;
            N_Years = years;
        }
        #endregion

        #region Methods
        private float interestAmount(float invest)
        {
            return invest * R_AnnualReturn / 12; 
        }
        private float fixedPayment()
        {
            return (float) (interestAmount(X_Invest) * Math.Pow(1 + R_AnnualReturn / 12, 12 * N_Years) 
                / (Math.Pow(1 + R_AnnualReturn / 12, 12 * N_Years) - 1));
        }
        private float currentInvestBalance(int monthDiff)
        {
            return (float) (X_Invest * (Math.Pow(1 + R_AnnualReturn / 12, 12 * N_Years)
                - Math.Pow(1 + R_AnnualReturn / 12, monthDiff)) / (Math.Pow(1 + R_AnnualReturn / 12, 12 * N_Years) - 1));
        }
        public float InterestSum()
        {
            float interest_sum = 0f;
            var fixed_payment = fixedPayment();
            int diff = (int)((CalculationDate - AgreementDate).Days / (365.2525 / 12));
            int time_month = N_Years * 12;
            List<float> interests = new List<float>();

            for (int i = diff; i <= time_month; i++)
            {
                var invest_balance = currentInvestBalance(i);
                var interest = interestAmount(invest_balance);
                interests.Add(interest);
                interest_sum += interest;

            }

            return (float) Math.Round(interest_sum, 2);
        }
        #endregion
    }
}
