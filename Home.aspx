<%@ Page Title="Welcome to Dan's Cafe" Language="C#" MasterPageFile="~/Navbar_v2.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MP_CS107L.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            position: relative;
            margin: 0;
            padding: 0;
            font-family: Arial, sans-serif;
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
                /*width: 80%;*/
                max-width: 100%;
                height: auto;
                /*display: block;*/
                /*margin: 0 auto;*/
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



    <form id="homepage" runat="server">
        <div class="contain">
            <p class="welcome">WELCOME TO DAN'S CAFE</p>
            <p class="intro">Indulge in the cozy place with quality foods and drinks here! Experience our fresh coffee</p>
        </div>

        <div class="grid-container my-5">
            <div class="square">
                <img src="images/decorations/latte.png" />
                <div class="desc">
                    DRINK NOW!
                </div>
                <p>With our freshly brewed coffee, choose any blends you like</p>
                <a href="#" class="button">TAKE A SIP</a>
            </div>
            <div class="square">
                <img src="images/decorations/pastries.png" />
                <div class="desc">
                    BON APPETIT!
                </div>
                <p>Try our most delectable pastries fresh for your taste</p>
                <a href="#" class="button">TAKE A BITE</a>
            </div>
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
    </form>
</asp:Content>
