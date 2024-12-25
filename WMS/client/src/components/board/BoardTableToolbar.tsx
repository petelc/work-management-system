import DeleteIcon from '@mui/icons-material/Delete';
import DetailsIcon from '@mui/icons-material/Details';
import FilterListIcon from '@mui/icons-material/FilterList';
import { alpha, IconButton, Toolbar, Tooltip, Typography } from '@mui/material';
import { Link } from 'react-router-dom';

interface BoardTableToolbarProps {
  numSelected: number;
  cabId: number;
}

export default function BoardTableToolbar(props: BoardTableToolbarProps) {
  const { numSelected, cabId } = props;

  return (
    <Toolbar
      sx={[
        {
          pl: { sm: 2 },
          pr: { xs: 1, sm: 1 },
        },
        numSelected > 0 && {
          bgcolor: (theme) =>
            alpha(
              theme.palette.primary.main,
              theme.palette.action.activatedOpacity
            ),
        },
      ]}
    >
      {numSelected > 0 ? (
        <Typography
          sx={{ flex: '1 1 100%' }}
          color='inherit'
          variant='subtitle1'
          component='div'
        >
          {numSelected} selected
        </Typography>
      ) : (
        <Typography
          sx={{ flex: '1 1 100%' }}
          variant='h6'
          id='tableTitle'
          component='div'
        >
          Submitted Requests
        </Typography>
      )}
      {numSelected > 0 ? (
        <>
          <Tooltip title='Details'>
            <IconButton component={Link} to={`/boards/${cabId}`}>
              <DetailsIcon />
            </IconButton>
          </Tooltip>
          <Tooltip title='Delete'>
            <IconButton>
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        </>
      ) : (
        <Tooltip title='Filter list'>
          <IconButton>
            <FilterListIcon />
          </IconButton>
        </Tooltip>
      )}
    </Toolbar>
  );
}
