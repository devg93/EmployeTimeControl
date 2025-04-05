import "./App.css";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Login from "./Components/Login/Login";
import Layout from "./Components/Layout";
import Home from "./Components/Home/Home";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import UserList from "./Components/User/UserList";

const queryClient = new QueryClient();

const router = createBrowserRouter([
  {
    path: "/",
    element: <Login />,
  },
  {
    path: "/admin",
    element: (
      <Layout>
        <Home />
      </Layout>
    ),
    children: [
      {
        path: "locker/list",
        element: <UserList />,
      },
    ],
  },
]);

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <RouterProvider router={router} />
    </QueryClientProvider>
  );
}

export default App;
