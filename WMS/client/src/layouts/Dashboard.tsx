import { Outlet } from 'react-router-dom';
import { DashboardLayout } from '@toolpad/core/DashboardLayout';
import { PageContainer } from '@toolpad/core/PageContainer';
import SidebarFooterAccount from '../components/sidebar/SidebarFooterAccount';
//import MainGrid from '../../components/maingrid/MainGrid';

/**
 * This is the outer page component for the dashboard functionality.
 * This handles the state and passes the data to the main grid component
 * @returns Main grid component
 */
export default function Dashboard() {
  return (
    <DashboardLayout
      slots={{
        toolbarAccount: () => null,
        sidebarFooter: SidebarFooterAccount,
      }}
    >
      <PageContainer>
        <Outlet />
      </PageContainer>
    </DashboardLayout>
  );
}
