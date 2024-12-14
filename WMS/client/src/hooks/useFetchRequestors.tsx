import { useEffect } from 'react';
import { fetchAllUsers } from '../pages/account/accountSlice';
import { useAppDispatch, useAppSelector } from '../store/hooks';

export default function useFetchRequestors() {
  //const users = useAppSelector(accountSelectors.selectAll);
  const { users } = useAppSelector((state) => state.account);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchAllUsers());
  }, [dispatch]);

  return {
    users,
  };
}
