import {
  TableHead,
  TableRow,
  TableCell,
  Checkbox,
  TableSortLabel,
  Box,
} from '@mui/material';
import { Order } from '../../helpers/utils/Comparators';
import { visuallyHidden } from '@mui/utils';

interface HeadCell {
  id: string;
  label: string;
  numeric: boolean;
  disablePadding?: boolean;
}

const headCells: readonly HeadCell[] = [
  { id: 'requestTitle', label: 'Request Title', numeric: false },
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
    id: 'approvalStatusName',
    label: 'Approval Status',
    numeric: false,
  },
  { id: 'createDate', label: 'Submitted Date', numeric: false },
];

interface RequestTableHeadProps {
  numSelected: number;
  //onRequestSort: (event: React.MouseEvent<unknown>, property: string) => void;
  onSelectAllClick: (event: React.ChangeEvent<HTMLInputElement>) => void;
  order: Order;
  orderBy: string;
  rowCount: number;
}

export default function RequestTableHead(props: RequestTableHeadProps) {
  const {
    onSelectAllClick,
    order,
    orderBy,
    numSelected,
    rowCount,
    //onRequestSort,
  } = props;

  //   const createSortHandler =
  //     (property: string) => (event: React.MouseEvent<unknown>) => {
  //       onRequestSort(event, property);
  //     };

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
            align={headCell.numeric ? 'right' : 'left'}
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
