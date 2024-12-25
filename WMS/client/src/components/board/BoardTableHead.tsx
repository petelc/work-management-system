import {
  TableCell,
  TableHead,
  TableRow,
  TableSortLabel,
  Box,
  Checkbox,
} from '@mui/material';
import { visuallyHidden } from '@mui/utils';
import { Order } from '../../helpers/utils/Comparators';

interface HeadCell {
  id: string;
  label: string;
  numeric: boolean;
  disablePadding?: boolean;
}

const headCells: readonly HeadCell[] = [
  { id: 'requestName', label: 'Request Title', numeric: false },
  // { id: 'priority', label: 'Priority', numeric: false },
  {
    id: 'requestTypeName',
    label: 'Request Type',
    numeric: false,
  },
  {
    id: 'requestorUsername',
    label: 'Requestor',
    numeric: false,
  },
  {
    id: 'votes',
    label: 'Votes',
    numeric: true,
  },
  { id: 'createDate', label: 'Submitted Date', numeric: false },
];

interface BoardTableHeadProps {
  numSelected: number;
  onSelectAllClick: (event: React.ChangeEvent<HTMLInputElement>) => void;
  order: Order;
  orderBy: string;
  rowCount: number;
}

export default function BoardTableHead(props: BoardTableHeadProps) {
  const { onSelectAllClick, order, orderBy, numSelected, rowCount } = props;

  return (
    <TableHead>
      <TableRow>
        <TableCell padding='checkbox'>
          <Checkbox
            color='primary'
            indeterminate={numSelected > 0 && numSelected < rowCount}
            checked={rowCount > 0 && numSelected === rowCount}
            onChange={onSelectAllClick}
            inputProps={{ 'aria-label': 'select all requests' }}
          />
        </TableCell>
        {headCells.map((headCell) => (
          <TableCell
            key={headCell.id}
            align={headCell.numeric ? 'center' : 'left'}
            padding={headCell.disablePadding ? 'none' : 'normal'}
            sortDirection={orderBy === headCell.id ? order : false}
          >
            <TableSortLabel
              active={orderBy === headCell.id}
              direction={orderBy === headCell.id ? order : 'asc'}
            >
              {headCell.label}
              {orderBy === headCell.id ? (
                <Box component='span' sx={visuallyHidden}>
                  {order === 'desc' ? 'sorted descending' : 'sorted ascending'}
                </Box>
              ) : null}
            </TableSortLabel>
          </TableCell>
        ))}
      </TableRow>
    </TableHead>
  );
}
