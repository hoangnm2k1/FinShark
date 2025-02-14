import React, { Fragment, JSX } from "react";
import Card from "../Card/Card";
import { CompanySearch } from "../../company";
import { v4 as uuidv4 } from "uuid";
import "./CardList.css";

interface Props {
  searchResults: CompanySearch[];
  onPortfolioCreate: (e: React.SyntheticEvent) => void;
}

const CardList: React.FC<Props> = ({
  searchResults,
  onPortfolioCreate,
}: Props): JSX.Element => {
  return (
    <table className="w-[95%] border-collapse mx-auto">
      <thead>
        <tr>
          <th>Company Name</th>
          <th>Currency</th>
          <th>Exchange</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        {searchResults.length > 0 ? (
          searchResults.map((result) => {
            return (
              <Card
                id={result.symbol}
                key={uuidv4()}
                searchResult={result}
                onPortfolioCreate={onPortfolioCreate}
              />
            );
          })
        ) : (
          <tr>
            <td className="mb-3 mt-3 text-xl font-semibold text-center md:text-xl" colSpan={4}>
              No results!
            </td>
          </tr>
        )}
      </tbody>
    </table>
  );
};

export default CardList;
