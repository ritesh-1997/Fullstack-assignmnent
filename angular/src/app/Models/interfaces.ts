export interface IStrategyInvestment{
    name: string;
    description: string;
    amount: number;
    funds:IFunds[];
}
export interface IFunds{
    name: string;
    percentage: number;
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
  
export interface IUserHoldingsRequest{
  phoneNumber: string;
  data:IHoldingsResponse[];
}
  export interface IHoldingsResponse {
    strategyName: string;
    investmentAmount: number;
    investmentMarketValue:number;
    holdingDetails: IHoldingDetails[];
  }
  
  export interface IHoldingDetails {
    fundName: string;
    investmentAmount: number; // Use number for monetary values in Angular
    marketValue: number;
  }

export interface IInvestment{
  count: number,
  data: IFundsInvestment[],
  success: boolean,
}
  export interface IFundsInvestment {
    strategyName: string;
    fundName: string;
    success: boolean; 
  }