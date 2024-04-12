export interface IStrategyInvestment{
    strategyName: string;
    amount: number;
    funds:IFunds[];
}
export interface IFunds{
    fundName: string;
    fundPercent: number;
    value: number;
}

export interface IInvestmentStrategy {
    percentage: any;
    name: string;
    description: string;
    funds: IInvestmentFund[];
  }
  
  export interface IInvestmentFund {
    name: string;
    percentage: number;
  }
  