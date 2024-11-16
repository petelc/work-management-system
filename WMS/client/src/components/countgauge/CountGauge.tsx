import {
  GaugeContainer,
  GaugeValueArc,
  GaugeReferenceArc,
  useGaugeState,
} from '@mui/x-charts/Gauge';
import { Box, CardContent, Stack, Typography } from '@mui/material';

export type CountGaugeProps = {
  title: string;
  value: number;
  valueMax: number;
  startAngle: number;
  endAngle: number;
};

function GaugePointer() {
  const { valueAngle, outerRadius, cx, cy } = useGaugeState();

  if (valueAngle === null) {
    return null;
  }

  const target = {
    x: cx + outerRadius * Math.sin(valueAngle),
    y: cy + outerRadius * Math.cos(valueAngle),
  };

  return (
    <g>
      <circle cx={cx} cy={cy} r={5} fill='red' />
      <path
        d={`M ${cx} ${cy} L ${target.x} ${target.y}`}
        stroke='red'
        strokeWidth={3}
      />
    </g>
  );
}

export default function CountGauge({
  title,
  value,
  valueMax,
  startAngle,
  endAngle,
}: CountGaugeProps) {
  //const { title, value, valueMax, startAngle, endAngle } = count;

  return (
    <CardContent>
      <Typography component='h2' variant='h4' gutterBottom>
        {title}
      </Typography>
      <Stack
        direction='column'
        sx={{
          justifyContent: 'space-between',
          flexGrow: '1',
          gap: 1,
        }}
      >
        <Stack sx={{ justifyContent: 'space-between' }}>
          <Stack
            direction='row'
            sx={{
              justifyContent: 'space-between',
              alignItems: 'center',
              mt: 2,
            }}
          >
            <Typography variant='h5' component='p'>
              {value}
            </Typography>
          </Stack>
          <Typography variant='caption' sx={{ color: 'text.secondary' }}>
            Submitted
          </Typography>
        </Stack>
        <Box sx={{ width: '100%', height: 240, mt: -10 }}>
          <GaugeContainer
            width={200}
            height={240}
            startAngle={startAngle}
            endAngle={endAngle}
            value={value}
            valueMax={valueMax}
            sx={{ m: 'auto' }}
          >
            <GaugeReferenceArc />
            <GaugeValueArc />
            <GaugePointer />
          </GaugeContainer>
        </Box>
      </Stack>
    </CardContent>
  );
}
