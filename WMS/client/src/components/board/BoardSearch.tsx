import { useState } from 'react';
import { TextField, debounce } from '@mui/material';
import { useAppDispatch, useAppSelector } from '../../store/hooks';
import { setBoardParams } from '../../pages/board/boardSlice';

export default function BoardSearch() {
  const { boardParams } = useAppSelector((state) => state.board);
  const [searchTerm, setSearchTerm] = useState(boardParams.searchTerm);
  const dispatch = useAppDispatch();

  const debouncedSearch = debounce((event: any) => {
    dispatch(setBoardParams({ searchTerm: event.target.value }));
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
