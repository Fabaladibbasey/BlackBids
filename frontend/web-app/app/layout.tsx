import type { Metadata } from "next";
import "./globals.css";
import Navbar from "./nav/Navbar";

export const metadata: Metadata = {
  title: "BlackBids",
  description: "BlackBids is a marketplace for anyone who prioritizes appreciation over depreciation.",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <Navbar />
        <main className='container mx-auto px-5 pt-5'>
          {children}
        </main>
      </body>
    </html>
  );
}
