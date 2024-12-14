import { useState } from 'react';
import { TextField, debounce } from '@mui/material';
import { useAppDispatch, useAppSelector } from '../../store/hooks';
import { setRequestParams } from '../../pages/request/requestSlice';

export default function RequestSearch() {
  const { requestParams } = useAppSelector((state) => state.request);
  const [searchTerm, setSearchTerm] = useState(requestParams.searchTerm);
  const dispatch = useAppDispatch();

  const debouncedSearch = debounce((event: any) => {
    dispatch(setRequestParams({ searchTerm: event.target.value }));
  }, 1000);

  return (
    <TextField
      label='Search Requests'
      variant='outlined'
      fullWidth
      value={searchTerm || ''}
      onChange={(event: any) => {
        setSearchTerm(event.target.value);
        debouncedSearch(event);
      }}
    />
  );
}
