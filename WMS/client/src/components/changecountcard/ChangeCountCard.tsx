import { useEffect } from 'react';
import { useAppDispatch, useAppSelector } from '../../store/configureStore';
import { fetchChangeCountsAsync } from '../../pages/dashboard/dashboardSlice';
import LoadingComponent from '../loading/LoadingComponent';
import StatCard from '../maingrid/StatCard';

export default function ChangeCountCard() {
  const dispatch = useAppDispatch();
  const count = useAppSelector((state) => state.dashboard.changeCounts);
  const { status: changeCountStatus } = useAppSelector(
    (state) => state.dashboard
  );

  useEffect(() => {
    if (!count) dispatch(fetchChangeCountsAsync());
  }, [count, dispatch]);

  if (changeCountStatus.includes('pending'))
    return <LoadingComponent message='Loading change counts..' />;

  console.log(count);

  return (
    <>
      <StatCard {...count} />
    </>
  );
}
