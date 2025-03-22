import React, { SyntheticEvent } from "react";
import { Link } from "react-router-dom";
import DeletePortfolio from "../DeletePortfolio/DeletePortfolio";
import { PortfolioGet } from "../../../Models/Portfolio";

interface Props {
  // portfolioValue: string;
  portfolioValue: PortfolioGet;
  onPortfolioDelete: (e: SyntheticEvent) => void;
}

const CardPortfolio = ({ portfolioValue, onPortfolioDelete }: Props) => {
  return (
    <div className="flex flex-col w-full p-8 space-y-4 text-center rounded-lg shadow-lg md:w-1/3">
      <Link
        // to={`/company/${portfolioValue}/company-profile`}
        to={`/company/${portfolioValue.symbol}/company-profile`}
        className="pt-6 text-xl font-bold"
      >
        {/* {portfolioValue} */}
        {portfolioValue.symbol}
      </Link>
      <DeletePortfolio
        // portfolioValue={portfolioValue}
        portfolioValue={portfolioValue.symbol}
        onPortfolioDelete={onPortfolioDelete}
      />
    </div>
  );
};

export default CardPortfolio;
