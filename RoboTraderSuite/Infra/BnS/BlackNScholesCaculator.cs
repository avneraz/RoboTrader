using System;
using System.Globalization;
using Infra.Enum;

//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Infra.BnS
{
    /// <summary>
    /// Black–Scholes formula:      
    ///
    ///Black–Scholes European Call Option Pricing Surface
    ///The Black–Scholes formula calculates the price of European put and call options. 
    ///It can be obtained by solving the Black–Scholes stochastic differential equation.
    ///The value of a call option for a non-dividend paying underlying stock in terms of the Black–Scholes parameters is:
    ///
    /// Also,
    ///
    ///The price of a corresponding put option based on put-call parity is:

    ///For both, as above:
    /// is the cumulative distribution function of the standard normal distribution
    ///T − t is the time to maturity
    ///spot is the spot price of the underlying asset
    ///strike is the strike price
    ///interestRate is the risk free rate (annual rate, expressed in terms of continuous compounding)
    /// σ is the volatility of returns of the underlying asset
    /// </summary>
    public class BlackNScholesCaculator
    {
        public BlackNScholesCaculator()
        {
            Multiplier = 100.0;
        }
        private double _d1;
        private double _d2;

        #region Properties

        public double CallValue { get; set; }

        public double PutValue { get; set; }

        /// <summary>
        /// Put or Call
        /// </summary>
        public EOptionType OptionType { get; set; }

        /// <summary>
        /// The option value as result of BNS model calculation
        /// </summary>
        public double OptionValue { get; set; }
        /// <summary>
        /// σ, the volatility of the stock's returns; 
        /// This is the square root of the quadratic variation of the stock's log price process.
        /// </summary>
        public double ImpliedVolatilities { get; set; }
        /// <summary>
        /// spot, be the price of the stock
        /// </summary>
        public double StockPrice { get; set; }
        /// <summary>
        /// The strike price (or exercise price) can be defined as the fixed price
        /// at which the owner of an option can purchase (in the case of a call), 
        /// or sell (in the case of a put)
        /// </summary>
        public double StrikePrice { get; set; }
        /// <summary>
        /// The risk-free rate represents the interest that an investor would expect 
        /// from an absolutely risk-free investment over a given period of time.
        /// </summary>
        public double RiskFreeInterestRate { get; set; }

        /// <summary>        
        /// The time for option's expiration.a time in years units; 
        /// </summary>
        public double ExpiryTime { get; set; }

        /// <summary>
        /// Get the number of working days until expired
        /// </summary>
        public double ExpiryTimeWorking { get; set; }

        public double DeltaCall { get; set; }

        public double DeltaPut { get; set; }

        public double GamaCall { get; set; }

        public double GamaPut { get; set; }

        public double VegaCall { get; set; }

        public double VegaPut { get; set; }

        public double ThetaCall { get; set; }

        public double ThetaPut { get; set; }

        public double Multiplier { get; set; }

        public int IterationCounter { get; private set; }


        /// <summary>
        /// The number of days left until the option expired!
        /// </summary>
        public int DayLefts
        {
            get { return _dayLefts; }
            set
            {
                _dayLefts = value;
                double dayLeft1 = _dayLefts - ((_dayLefts / 7) * 2);
                ExpiryTimeWorking = (dayLeft1 / 250.0d);//= 365 - (2 * 53)==> get the year working days.
                ExpiryTime = _dayLefts / 365.0d;
            }
        }
        private int _dayLefts;
        #endregion

        #region BNS Model Private Methods

        private double CalculateD1()
        {
            double d1 =
                (Math.Log(StockPrice / StrikePrice) +
                    ExpiryTime * (RiskFreeInterestRate + ImpliedVolatilities * ImpliedVolatilities / 2)) /
                    (ImpliedVolatilities * Math.Sqrt(ExpiryTime));
            return d1;
        }

        private double CalculateD2()
        {
            double d2 =
                (Math.Log(StockPrice / StrikePrice) +
                    ExpiryTime * (RiskFreeInterestRate - ImpliedVolatilities * ImpliedVolatilities / 2)) /
                    (ImpliedVolatilities * Math.Sqrt(ExpiryTime));
            return d2;
        }

        private double CalculateNOfX(double x)
        {
            if (x < 0)
            {
                return (1 - (CalculateNOfX(-x)));
            }

            const double alpha = 0.2316419;
            const double a1 = 0.31938153;
            const double a2 = -0.356563782;
            const double a3 = 1.781477937;
            const double a4 = -1.821255978;
            const double a5 = 1.330274429;




            double k = 1.0 / (1.0 + alpha * x);
            double nX1 = (Math.Exp(-(x * x / 2))) /
                         Math.Sqrt((2 * Convert.ToDouble(Math.PI.ToString(CultureInfo.InvariantCulture))));
            double result = 1 - (nX1 * (a1 * k + a2 * k * k + a3 * k * k * k + a4 * Math.Pow(k, 4.0) + a5 * Math.Pow(k, 5.0)));
            return result;
        }

        private void CalculateTheta()
        {
            ThetaCall = -(
                (
                    (
                        StockPrice * ((Math.Exp(-(_d1 * _d1 / 2))) /
                        Math.Sqrt(2.0 * Math.PI)) * ImpliedVolatilities
                    ) /
                    (2 * Math.Sqrt(ExpiryTime))
                ) -
                (
                    RiskFreeInterestRate * StrikePrice *
                    Math.Exp(-RiskFreeInterestRate * ExpiryTime) * CalculateNOfX(_d2)
                )) / 2.5;

            ThetaPut = (
                (
                    -(
                        StockPrice * ((Math.Exp(-(_d1 * _d1 / 2))) /
                        Math.Sqrt(2.0 * Math.PI)) * ImpliedVolatilities
                    ) /
                    (2 * Math.Sqrt(ExpiryTime))
                ) +
                (
                    RiskFreeInterestRate * StrikePrice *
                    Math.Exp(-RiskFreeInterestRate * ExpiryTime) * CalculateNOfX(-_d2)
                )) / 2.5;

        }

        private void CalculateGama()
        {
            double sigma = (Multiplier) * ((Math.Exp(-(_d1 * _d1 / 2))) / Math.Sqrt(2.0 * Math.PI)) /
                             (StockPrice * ImpliedVolatilities * Math.Sqrt(ExpiryTime));
            GamaCall = GamaPut = sigma;
        }

        private void CalculateDelta()
        {
            StockPrice += 1.0;
            double call = CalculateCallValue();
            DeltaCall = Math.Abs(call - CallValue);
            double put = CalculatePutValue();
            DeltaPut = -Math.Abs(put - PutValue);
            //Return the original value:
            StockPrice -= 1.0;
        }

        #endregion

        #region Public Methods

        public void CalculateAll()
        {
            _d1 = CalculateD1();
            _d2 = CalculateD2();

            CallValue = CalculateCallValue();
            PutValue = CalculatePutValue();

            CalculateDelta();

            CalculateGama();

            CalculateTheta();
        }

        public double CalculateCallValue()
        {
            var callValue = Multiplier *
                    (StockPrice * CalculateNOfX(_d1) -
                     CalculateNOfX(_d2) * StrikePrice * Math.Exp(-RiskFreeInterestRate * ExpiryTime));
            return callValue;
        }

        public double CalculatePutValue()
        {
            var putValue = Multiplier *
                    (CalculateNOfX(-_d2) * StrikePrice * Math.Exp(-RiskFreeInterestRate * ExpiryTime) -
                     (StockPrice * CalculateNOfX(-_d1)));
            return putValue;
        }

        #endregion

        #region Calculates Implied Volatility


        /// <summary>
        /// Calculates implied volatility for the Black Scholes formula using
        /// binomial search algorithm. 
        /// </summary>
        /// <param name="callOptionPrice">The Call option price.</param>
        /// <returns></returns>
        public double GetCallIVBisections(double callOptionPrice)
        {
            double impliedVolatility = CallOptionPriceIVBisections(StockPrice, StrikePrice,
                RiskFreeInterestRate, ExpiryTime, callOptionPrice);
            return impliedVolatility;
        }

        /// <summary>
        /// Calculates implied volatility for the Black Scholes formula using
        /// binomial search algorithm. 
        /// </summary>
        /// <param name="putOptionPrice">The Put option price.</param>
        /// <returns></returns>
        public double GetPutIVBisections(double putOptionPrice)
        {
            double impliedVolatility = PutOptionPriceIVBisections(StockPrice, StrikePrice,
                RiskFreeInterestRate, ExpiryTime, putOptionPrice);
            return impliedVolatility;
        }

        /// <summary>
        /// Calculates implied volatility for the Black Scholes formula using
        /// binomial search algorithm
        ///
        /// Converted to C# from "Financial Numerical Recipes in C" by:
        /// Bernt Arne Odegaard
        /// http://finance.bi.no/~bernt/gcc_prog/index.html
        ///
        /// (NOTE: In the original code a large negative number was used as an
        /// exception handling mechanism.  This has been replace with a generic
        /// 'Exception' that is thrown.  The original code is in place and commented
        /// if you want to use the pure version of this code)
        /// </summary>
        /// <param name="spot">spot (underlying) price</param>
        /// <param name="strike">strike (exercise) price</param>
        /// <param name="interestRate">interest rate</param>
        /// <param name="time">time to maturity</param>
        /// <param name="optionPrice">The price of the option</param>
        /// <returns>Sigma (implied volatility)</returns>
        public double CallOptionPriceIVBisections(double spot, double strike, double interestRate,
                double time, double optionPrice)
        {
            // check for arbitrage violations.
            if (optionPrice < 0.99 * (spot - strike * Math.Exp(-time * interestRate)))
            {
                return 0.0;                             // Option price is too low if this happens
            }

            // simple binomial search for the implied volatility.
            // relies on the value of the option increasing in volatility
            const double ACCURACY = 1.0e-5; // make this smaller for higher accuracy
            const int MAX_ITERATIONS = 100;
            const double HIGH_VALUE = 1e10;
            //const double ERROR = -1e40;  // <--- original code

            // want to bracket sigma. first find a maximum sigma by finding a sigma
            // with a estimated price higher than the actual price.
            double sigmaLow = 1e-5;
            double sigmaHigh = 0.3;

            var blackNScholesCaculator = new BlackNScholesCaculator
            {
                ExpiryTime = time,
                RiskFreeInterestRate = interestRate,
                StockPrice = spot,
                StrikePrice = strike,
                ImpliedVolatilities = sigmaHigh
            };

            blackNScholesCaculator.CalculateAll();
            double price = blackNScholesCaculator.CallValue;

            while (price < optionPrice)
            {
                sigmaHigh = 2.0 * sigmaHigh; // keep doubling.
                blackNScholesCaculator.ImpliedVolatilities = sigmaHigh;
                blackNScholesCaculator.CalculateAll();
                price = blackNScholesCaculator.CallValue;

                if (sigmaHigh > HIGH_VALUE)
                {
                    //return ERROR; // panic, something wrong.     // <--- original code
                    throw new Exception("panic, something wrong."); // Comment this line if you uncomment the line above
                }
            }
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                double sigma = (sigmaLow + sigmaHigh) * 0.5;

                blackNScholesCaculator.ImpliedVolatilities = sigma;
                blackNScholesCaculator.CalculateAll();
                price = blackNScholesCaculator.CallValue;

                double test = (price - optionPrice);
                if (Math.Abs(test) < ACCURACY)
                {
                    IterationCounter = i;
                    return sigma;
                }
                if (test < 0.0)
                    sigmaLow = sigma;
                else
                    sigmaHigh = sigma;
            }
            //return ERROR;      // <--- original code
            throw new Exception("An error occurred the iteration didn't succeed"); // Comment this line if you uncomment the line above
        }

        /// <summary>
        /// Calculates implied volatility for the Black Scholes formula using
        /// binomial search algorithm
        ///
        /// Converted to C# from "Financial Numerical Recipes in C" by:
        /// Bernt Arne Odegaard
        /// http://finance.bi.no/~bernt/gcc_prog/index.html
        ///
        /// (NOTE: In the original code a large negative number was used as an
        /// exception handling mechanism.  This has been replace with a generic
        /// 'Exception' that is thrown.  The original code is in place and commented
        /// if you want to use the pure version of this code)
        /// </summary>
        /// <param name="spot">spot (underlying) price</param>
        /// <param name="strike">strike (exercise) price</param>
        /// <param name="interestRate">interest rate</param>
        /// <param name="time">time to maturity</param>
        /// <param name="optionPrice">The price of the option</param>
        /// <returns>Sigma (implied volatility)</returns>
        public double PutOptionPriceIVBisections(double spot, double strike, double interestRate,
                double time, double optionPrice)
        {
            // check for arbitrage violations.
            if (optionPrice < 0.99 * (spot - strike * Math.Exp(-time * interestRate)))
            {
                return 0.0;   // Option price is too low if this happens
            }

            // simple binomial search for the implied volatility.
            // relies on the value of the option increasing in volatility
            const double ACCURACY = 1.0e-5; // make this smaller for higher accuracy
            const int MAX_ITERATIONS = 100;
            const double HIGH_VALUE = 1e10;
            //const double ERROR = -1e40;  // <--- original code

            // want to bracket sigma. first find a maximum sigma by finding a sigma
            // with a estimated price higher than the actual price.
            double sigmaLow = 1e-5;
            double sigmaHigh = 0.3;

            var blackNScholesCaculator = new BlackNScholesCaculator
            {
                ExpiryTime = time,
                RiskFreeInterestRate = interestRate,
                StockPrice = spot,
                StrikePrice = strike,
                ImpliedVolatilities = sigmaHigh
            };

            blackNScholesCaculator.CalculateAll();
            double price = blackNScholesCaculator.PutValue;

            while (price < optionPrice)
            {
                sigmaHigh = 2.0 * sigmaHigh; // keep doubling.
                blackNScholesCaculator.ImpliedVolatilities = sigmaHigh;
                blackNScholesCaculator.CalculateAll();
                price = blackNScholesCaculator.PutValue;

                if (sigmaHigh > HIGH_VALUE)
                {
                    //return ERROR; // panic, something wrong.     // <--- original code
                    throw new Exception("panic, something wrong."); // Comment this line if you uncomment the line above
                }
            }
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                double sigma = (sigmaLow + sigmaHigh) * 0.5;

                blackNScholesCaculator.ImpliedVolatilities = sigma;
                blackNScholesCaculator.CalculateAll();
                price = blackNScholesCaculator.PutValue;

                double test = (price - optionPrice);
                if (Math.Abs(test) < ACCURACY)
                {
                    IterationCounter = i;
                    return sigma;
                }
                if (test < 0.0)
                    sigmaLow = sigma;
                else
                    sigmaHigh = sigma;
            }
            //return ERROR;      // <--- original code
            throw new Exception("An error occurred"); // Comment this line if you uncomment the line above
        }

        #endregion

        #region Statics Test Methods

        public static bool TestCallCalculation()
        {
            var o = new BlackNScholesCaculator
            {
                //ExpiryTime = 0.25,
                DayLefts = 90,
                ImpliedVolatilities = 0.2,
                OptionType = EOptionType.Call,
                RiskFreeInterestRate = 0.1,
                StockPrice = 50,
                StrikePrice = 40
            };
            double callValue = o.CalculateCallValue();
            if (Math.Abs(callValue - 11.01) > 0.1)
                return false;

            return true;
        }
        public static bool TestPutCalculation()
        {
            var o = new BlackNScholesCaculator
            {
                DayLefts = 90,
                ImpliedVolatilities = 0.2,
                OptionType = EOptionType.Call,
                RiskFreeInterestRate = 0.1,
                StockPrice = 50,
                StrikePrice = 40
            };
            var putValue = o.CalculatePutValue();
            return !(Math.Abs(putValue - 0.078) > 0.001);
        }

        #endregion

        #region Not used code
        //public double CalculateImpliedVolatilityBNSNewton(double callOptionPrice)
        //{
        //    double impliedVolatility = OptionPriceImpliedVolatilityCallBlackScholesNewton(StockPrice, StrikePrice,
        //        RiskFreeInterestRate, ExpiryTime, callOptionPrice);
        //    return impliedVolatility;
        //}
        /// <summary>
        /// Calculates implied volatility for the Black Scholes formula using
        /// the Newton-Raphson formula
        ///
        /// Converted to C# from "Financial Numerical Recipes in C" by:
        /// Bernt Arne Odegaard
        /// http://finance.bi.no/~bernt/gcc_prog/index.html
        ///
        /// (NOTE: In the original code a large negative number was used as an
        /// exception handling mechanism.  This has been replace with a generic
        /// 'Exception' that is thrown.  The original code is in place and commented
        /// if you want to use the pure version of this code)
        /// </summary>
        /// <param name="spot">spot (underlying) price</param>
        /// <param name="strike">strike (exercise) price</param>
        /// <param name="interestRate">interest rate</param>
        /// <param name="time">time to maturity</param>
        /// <param name="optionPrice">The price of the option</param>
        /// <returns>Sigma (implied volatility)</returns>
        public double OptionPriceImpliedVolatilityCallBlackScholesNewton(double spot, double strike, double interestRate,
                double time, double optionPrice)
        {
            // check for arbitrage violations. Option price is too low if this happens
            if (optionPrice < 0.99 * (spot - strike * Math.Exp(-time * interestRate)))
            {
                return 0.0;
            }

            const int MAX_ITERATIONS = 100;
            const double ACCURACY = 1.0e-5;
            double tSqrt = Math.Sqrt(time);

            var blackNScholesCaculator = new BlackNScholesCaculator
            {
                ExpiryTime = time,
                RiskFreeInterestRate = interestRate,
                StockPrice = spot,
                StrikePrice = strike,
                //ImpliedVolatilities = sigmaHigh
            };

            double sigma = (optionPrice / spot) / (0.398 * tSqrt);    // find initial value
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                blackNScholesCaculator.ImpliedVolatilities = sigma;
                blackNScholesCaculator.CalculateAll();
                double price = blackNScholesCaculator.CallValue;
                // price = OptionPriceCallBlackScholes(spot, strike, interestRate, sigma, time);
                double diff = optionPrice - price;
                if (Math.Abs(diff) < ACCURACY)
                    return sigma;
                double d1 = (Math.Log(spot / strike) + interestRate * time) / (sigma * tSqrt) + 0.5 * sigma * tSqrt;

                double vega = spot * tSqrt * CumulativeNormDist(d1);
                sigma = sigma + diff / vega;
            }
            //return -99e10;  // something screwy happened, should throw exception  // <--- original code
            throw new Exception("An error occurred"); // Comment this line if you uncomment the line above
        }
        /// <summary>
        /// Cumulative normal distribution
        /// Abramowiz and Stegun approximation (1964)
        ///
        /// Converted to C# from "Financial Numerical Recipes in C" by:
        /// Bernt Arne Odegaard
        /// http://finance.bi.no/~bernt/gcc_prog/index.html
        /// </summary>
        /// <param name="z">Value to test</param>
        /// <returns>Cumulative normal distribution</returns>
        public static double CumulativeNormDist(double z)
        {
            if (z > 6.0) { return 1.0; }; // this guards against overflow 
            if (z < -6.0) { return 0.0; };

            double b1 = 0.31938153;
            double b2 = -0.356563782;
            double b3 = 1.781477937;
            double b4 = -1.821255978;
            double b5 = 1.330274429;
            double p = 0.2316419;
            double c2 = 0.3989423;

            double a = Math.Abs(z);
            double t = 1.0 / (1.0 + a * p);
            double b = c2 * Math.Exp((-z) * (z / 2.0));
            double n = ((((b5 * t + b4) * t + b3) * t + b2) * t + b1) * t;
            n = 1.0 - b * n;
            if (z < 0.0)
                n = 1.0 - n;
            return n;
        }

        #endregion


    }
}

