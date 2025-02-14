import React, { JSX, SyntheticEvent } from "react";
import "./Card.css";
import { CompanySearch } from "../../company";
import AddPortfolio from "../Portfolio/AddPortfolio/AddPortfolio";
import { Link } from "react-router";
import { text } from "stream/consumers";

interface Props {
  id: string;
  searchResult: CompanySearch;
  onPortfolioCreate: (e: SyntheticEvent) => void;
}

const Card: React.FC<Props> = ({
  id,
  searchResult,
  onPortfolioCreate,
}: Props): JSX.Element => {
  return (
    <tr key={id} id={id}>
      <td>
        <h2 className="card-title font-bold m-0 md:text-left flex-1">
          <Link
            className="text-[#2d106a] no-underline"
            to={`/company/${searchResult.symbol}/company-profile`}
          >
            {searchResult.name} ({searchResult.symbol})
          </Link>
        </h2>
      </td>
      <td className="text-gray-800 m-0">{searchResult.currency}</td>
      <td className="font-bold text-gray-800 m-0">
        {searchResult.exchangeShortName} - {searchResult.stockExchange}
      </td>
      <td className="left">
        <AddPortfolio
          onPortfolioCreate={onPortfolioCreate}
          symbol={searchResult.symbol}
        />
      </td>
    </tr>
  );
};

export default Card;
