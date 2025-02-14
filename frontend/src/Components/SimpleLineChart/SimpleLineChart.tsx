import React from "react";
import { LineChart, Line, XAxis, YAxis, ResponsiveContainer } from "recharts";

type Props = {
  data: any;
  xAxis: string;
  dataKey: string;
};

const SimpleLineChart = ({ data, xAxis, dataKey }: Props) => {
  const LineChartAny = LineChart as any;

  return (
    <>
      <ResponsiveContainer width={"99%"} height={500}>
        <LineChartAny
          data={data}
          margin={{
            top: 10,
            right: 30,
            left: 10,
            bottom: 5,
          }}
        >
          <Line
            type="monotone"
            dataKey={dataKey}
            stroke="#8884d8"
            activeDot={{ r: 8 }}
          />
          <XAxis dataKey={xAxis} />
          <YAxis />
        </LineChartAny>
      </ResponsiveContainer>
    </>
  );
};

export default SimpleLineChart;
