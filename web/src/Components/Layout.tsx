import { Content, Footer } from "antd/es/layout/layout";
import { ReactNode } from "react";

export default function Layout({ children }: { children: ReactNode }) {
  return (
    <div>
      <Layout>
        <Content
          style={{
            margin: "24px 16px",
            padding: 24,
            backgroundColor: "#fff",
          }}
        >
          {children}
        </Content>

        <Footer style={{ textAlign: "center" }}>©2024 MyKeyBox</Footer>
      </Layout>
    </div>
  );
}
