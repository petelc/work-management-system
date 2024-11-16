import Card from '@mui/material/Card';

import CountGauge, { CountGaugeProps } from '../countgauge/CountGauge';
import LoadingComponent from '../loading/LoadingComponent';
import useRequestCounts from '../../hooks/useRequestCounts';

export type RequestCountProps = {
  title: string;
  value: number;
  valueMax: number;
  startAngle: number;
  endAngle: number;
};

export default function RequestCountCard() {
  const { counts, countsLoaded } = useRequestCounts();
  const { title, value, valueMax, startAngle, endAngle }: CountGaugeProps =
    counts;
  //const dispatch = useAppDispatch();

  //console.log(counts);

  if (!countsLoaded) <LoadingComponent message='Loading counts...' />;

  return (
    <Card variant='outlined' sx={{ height: '100%', flexGrow: 1 }}>
      <CountGauge
        title={title}
        value={value}
        valueMax={valueMax}
        startAngle={startAngle}
        endAngle={endAngle}
      />
    </Card>
  );
}
