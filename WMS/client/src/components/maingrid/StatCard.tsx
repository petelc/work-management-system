// import { useTheme } from '@mui/material/styles';
import Box from '@mui/material/Box';
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Stack from '@mui/material/Stack';
import Typography from '@mui/material/Typography';
import {
  GaugeContainer,
  GaugeValueArc,
  GaugeReferenceArc,
  useGaugeState,
} from '@mui/x-charts/Gauge';
import { RequestCount } from '../../models/requestCounts';

interface Props {
  requestCounts: RequestCount;
}

function GaugePointer() {
  const { valueAngle, outerRadius, cx, cy } = useGaugeState();

  if (valueAngle === null) {
    return null;
  }

  const target = {
    x: cx + outerRadius * Math.sin(valueAngle),
    y: cy - outerRadius * Math.cos(valueAngle),
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

export default function StatCard({ requestCounts }: Props) {
  return (
    <Card variant='outlined' sx={{ height: '100%', flexGrow: 1 }}>
      <CardContent>
        <Typography component='h2' variant='h4' gutterBottom>
          {requestCounts.title}
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
                {requestCounts.value}
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
              startAngle={requestCounts.startAngle}
              endAngle={requestCounts.endAngle}
              value={requestCounts.value}
              valueMax={requestCounts.valueMax}
              sx={{ m: 'auto' }}
            >
              <GaugeReferenceArc />
              <GaugeValueArc />
              <GaugePointer />
            </GaugeContainer>
          </Box>
        </Stack>
      </CardContent>
    </Card>
  );
}
