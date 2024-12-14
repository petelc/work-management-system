import { useEffect } from 'react';
import { fetchTypes } from '../pages/request/requestSlice';
import { useAppSelector, useAppDispatch } from '../store/hooks';

export default function useFetchRequestTypes() {
  //const {types} = useAppSelector(requestSelectors.selectAll);
  const { types } = useAppSelector((state) => state.request);
  const dispatch = useAppDispatch();

  useEffect(() => {
    dispatch(fetchTypes());
  }, [dispatch]);

  return { types };
}
