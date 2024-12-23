import { Box, Paper } from '@mui/material';
import Grid from '@mui/material/Grid2';
import useBoards from '../../hooks/useBoards';
import LoadingComponent from '../../components/loading/LoadingComponent';
import BoardTable from '../../components/board/BoardTable';

export default function Board() {
  const { boards, boardsLoaded } = useBoards();

  if (!boardsLoaded) return <LoadingComponent message='Loading boards...' />;

  return (
    <Box sx={{ width: '100%', maxWidth: { sm: '100%', md: '1700px' } }}>
      <Grid container columnSpacing={3}>
        <Grid size={{ xs: 12 }}>
          <Paper sx={{ mb: 2 }}>Search</Paper>
        </Grid>
        <Grid size={{ xs: 12 }}>
          <BoardTable boards={boards} />
        </Grid>
        <Grid size={{ xs: 3 }} />
      </Grid>
    </Box>
  );
}
