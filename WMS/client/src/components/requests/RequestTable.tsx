import { useState } from 'react';
import Paper from '@mui/material/Paper';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TablePagination from '@mui/material/TablePagination';
import TableRow from '@mui/material/TableRow';
import { useAppSelector } from '../../store/configureStore';
import { Request } from '../../models/request';
import LoadingComponent from '../loading/LoadingComponent';

interface Column {
  id:
    | 'requestTitle'
    | 'priority'
    | 'requestTypeName'
    | 'requestorUsername'
    | 'approvalStatusName'
    | 'createDate';
  label?: string;
  minWidth?: number;
  align?: 'right';
  format?(value: number): string;
}

interface Props {
  requests: Request[];
}

const columns: readonly Column[] = [
  { id: 'requestTitle', label: 'Request Title', minWidth: 170 },
  { id: 'priority', label: 'Priority', minWidth: 100 },
  { id: 'requestTypeName', label: 'Request Type', minWidth: 100 },
  { id: 'requestorUsername', label: 'Requestor', minWidth: 170 },
  { id: 'approvalStatusName', label: 'Approval Status', minWidth: 100 },
  { id: 'createDate', label: 'Create Date', minWidth: 100 },
];

export default function RequestTable({ requests }: Props) {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(10);
  const { requestsLoaded } = useAppSelector((state) => state.request);

  const handleChangePage = (event: unknown, newPage: number) => {
    setPage(newPage);
  };

  const handleChangeRowsPerPage = (
    event: React.ChangeEvent<HTMLInputElement>
  ) => {
    setRowsPerPage(+event.target.value);
    setPage(0);
  };

  if (!requestsLoaded)
    return <LoadingComponent message='Loading requests...' />;

  return (
    <Paper sx={{ width: '100%', overflow: 'hidden' }}>
      <TableContainer sx={{ maxHeight: 440 }}>
        <Table stickyHeader aria-label='requests table'>
          <TableHead>
            <TableRow>
              {columns.map((column) => (
                <TableCell
                  key={column.id}
                  align={column.align}
                  style={{ minWidth: column.minWidth }}
                >
                  {column.label}
                </TableCell>
              ))}
            </TableRow>
          </TableHead>
          <TableBody>
            {requests
              .slice(page * rowsPerPage, page * rowsPerPage + rowsPerPage)
              .map((request) => {
                return (
                  <TableRow
                    hover
                    role='checkbox'
                    tabIndex={-1}
                    key={request.requestId}
                  >
                    {columns.map((column) => {
                      const value = request[column.id];
                      return (
                        <TableCell key={column.id} align={column.align}>
                          {column.format && typeof value === 'number'
                            ? column.format(value)
                            : value}
                        </TableCell>
                      );
                    })}
                  </TableRow>
                );
              })}
          </TableBody>
        </Table>
      </TableContainer>
      <TablePagination
        rowsPerPageOptions={[10, 25, 100]}
        component='div'
        count={requests.length}
        rowsPerPage={rowsPerPage}
        page={page}
        onPageChange={handleChangePage}
        onRowsPerPageChange={handleChangeRowsPerPage}
      />
    </Paper>
  );
}
