<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Navbar_v2.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="MP_CS107L.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--links--%>
    <link rel="stylesheet" type="text/css" href="Styles/contact.css" />
    <link rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.1/css/all.min.css" />

    <style>
        body {
            position: relative;
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
            color: rgb(56, 27, 13);
        }

        .contactUs {
            margin-bottom: 7rem;
        }

        h2 {
            font-size: 60px;
            font-weight: 600;
        }


        body::before {
            content: "";
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-image: url(images/decorations/coffee_wall.jpg);
            background-size: cover;
            background-position: top;
            background-repeat: no-repeat;
            z-index: -1;
            opacity: 0.5;
        }

        .contain {
            margin: 200px auto 150px auto;
            width: 80%;
            text-align: center;
            color: white;
        }

        .intro {
            font-size: 25px;
            color: rgb(56, 27, 13);
            font-weight: lighter;
        }

        .contact-info {
            font-size: 22px;
            font-weight: 500;
        }

        .welcome {
            font-size: 60px;
            font-weight: 600;
            color: rgb(56, 27, 13);
        }

        .grid-container {
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            padding: 10px;
            margin-bottom: 150px;
        }

        .square {
            width: 500px;
            background-color: rgb(56, 27, 13);
            margin: 20px;
            text-align: center;
            box-sizing: border-box;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

            .square p {
                margin: 10px 20px;
                color: white;
            }

            .square img {
                max-width: 100%;
                height: auto;
            }

        .desc {
            color: white;
            font-size: 16px;
            margin-bottom: 10px;
            margin-top: 10px;
        }

        .button {
            background-color: rgb(56, 27, 13);
            border: 2px solid white;
            color: white;
            cursor: pointer;
            font-size: 20px;
            width: 200px;
            font-weight: lighter;
            transition: all 0.5s;
            border-radius: 15px;
            display: inline-block;
            padding: 10px 20px;
            text-decoration: none;
            margin-bottom: 20px;
            margin-top: 30px;
            vertical-align: top;
        }

            .button:hover {
                padding-right: 30px;
            }

        footer {
            background-color: white;
            border-top: 0.5px solid gray;
            padding: 20px 0;
            text-align: center;
        }

        h3 {
            margin-left: 0;
        }

        .list {
            padding-left: 0;
            list-style: none;
        }

        .infooter {
            display: flex;
            justify-content: space-around;
            flex-wrap: wrap;
            margin-top: 3rem;
            margin-bottom: 3rem;
        }

        .foot-square {
            padding: 0 20px;
            box-sizing: border-box;
            flex: 1 0 25%;
        }

        li {
            margin-bottom: 8px;
        }

        @media screen and (max-width: 900px) {
            .grid-container {
                flex-direction: column;
                align-items: center;
            }

            .square {
                width: 80%;
            }
        }
    </style>





    <div class="contact-section">
        <div class="title">
            <h2>Contact Us</h2>
            <p class="contact-info">
                Have any questions or feedback?
               Reach out to us here! Our dedicated team is ready to assist you with any inquiries, 
               support requests, or suggestions you may have. Your satisfaction is our priority, 
               and we're committed to providing you with the best experience possible. Feel free to 
               contact us via Facebook, Instagram, or TikTok. We look forward to hearing from you!
            </p>
        </div>
        <form runat="server">
            <div class="contactUs">
                <div class="card">
                    <div class="icon">
                        <i class="fa-brands fa-square-facebook"></i>
                    </div>
                    <h4>Facebook</h4>
                    <asp:Button runat="server" class="btnStyle" Text="Visit" OnClientClick="window.open('https://www.facebook.com/', '_blank'); return false;" />

                </div>
                <div class="card">
                    <div class="icon">
                        <i class="fa-brands fa-square-instagram"></i>
                    </div>
                    <h4>Instagram</h4>
                    <asp:Button runat="server" class="btnStyle" Text="Visit" OnClientClick="window.open('https://www.instagram.com/'); return false;" />
                </div>
                <div class="card">
                    <div class="icon">
                        <i class="fa-brands fa-tiktok"></i>
                    </div>
                    <h4>TikTok</h4>
                    <asp:Button runat="server" class="btnStyle" Text="Visit" OnClientClick="window.open('https://www.tiktok.com/@dans.cafe', '_blank'); return false;" />
                </div>
            </div>



        </form>
    </div>
    <footer>
        <div class="infooter">
            <div class="foot-square">
                <a href="Home.aspx">
                    <img src="/images/decorations/logo.png" height="50" class="d-inline-block align-top" alt="">
                </a>
            </div>
            <div class="foot-square">
                <h3 class="links">About Us</h3>
                <ul class="list">
                    <li>Our Company</li>
                    <li>Stories and News</li>
                    <li>Customer Service</li>
                    <li>Careers</li>
                </ul>
            </div>

            <div class="foot-square">
                <h3 class="links">Order Online</h3>
                <ul class="list">
                    <li>Order on the Web App</li>
                    <li>Delivery</li>
                    <li>Send eGifts</li>
                    <li>Grab Partnership</li>
                </ul>
            </div>

            <div class="foot-square">
                <h3 class="links">Rewards</h3>
                <ul class="list">
                    <li>My Account</li>
                    <li>View Transactions</li>
                    <li>Reload</li>
                    <li>FAQs</li>
                </ul>
            </div>
        </div>
    </footer>
</asp:Content>
