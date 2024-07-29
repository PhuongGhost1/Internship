import React, { useState, useEffect, useRef, useContext } from "react";
import "./Cart.css";
import Box from "@mui/material/Box";
import Rating from "@mui/material/Rating";
import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";

import { MdPayments, MdOutlineDeleteForever } from "react-icons/md";
import { GoBookmark } from "react-icons/go";
import { BsBarChartLine } from "react-icons/bs";
import { IoVideocamOutline } from "react-icons/io5";
import { AiOutlineFieldTime } from "react-icons/ai";
import { TiStarOutline } from "react-icons/ti";
import { PiUserCircleFill } from "react-icons/pi";
import { Button, Stack } from "@mui/material";
import { CiCreditCard2 } from "react-icons/ci";
import { RiPaypalFill } from "react-icons/ri";
import { IoWalletSharp } from "react-icons/io5";

import ApiService from "../../../api/ApiService";
import { Link } from "react-router-dom";
import { IoIosArrowRoundBack, IoIosArrowRoundForward } from "react-icons/io";
import Modal from "react-modal";
import { AuthContext } from "../../../pages/Context/AuthContext";

Modal.setAppElement("#root");

export default function Cart({ user }) {
  const [datas, setDatas] = useState([]);
  const [dataFull, setDataFull] = useState([]);
  const [checkedItems, setCheckedItems] = useState({});
  const [total, setTotal] = useState(0);
  const itemsPerPage = 10;
  const [pagination, setPagination] = useState(1);
  const resultsRef = useRef(null);
  const [isLeftDisabled, setIsLeftDisabled] = useState(true);
  const [isRightDisabled, setIsRightDisabled] = useState(false);
  const [isOpenVisible, setIsOpenVisible] = useState(false);

  const fetchCartData = async () => {
    try {
      const viewcartData = await ApiService.getCart(user.id);
      setDatas(viewcartData.carts);
      const initialCheckedState = {};
      viewcartData.carts.forEach((cart) => {
        cart.cartCourses.forEach((cc) => {
          initialCheckedState[cc.course.id] = false;
        });
      });
      setCheckedItems(initialCheckedState);
    } catch (error) {
      console.error("Error fetching cart data:", error);
    }
  };

  useEffect(() => {
    fetchCartData();
  }, []);

  const addCourseToCart = async (CourseId, UserId) => {
    try {
      const response = await ApiService.getCart(UserId);
      const cart =
        response.carts && response.carts.length > 0 ? response.carts[0] : null;

      if (!cart) {
        console.error("No cart found for user.");
        return;
      }

      const isInCart = await ApiService.checkCourseInCart(cart.id, CourseId);

      if (isInCart) {
        alert("The course is already in the cart.");
        return;
      }

      await ApiService.addCourseToCart(CourseId, UserId);
      fetchCartData();
    } catch (error) {
      console.error("Error adding course to cart:", error);
    }
  };

  const removeCourseFromCart = async (cartCourseId) => {
    try {
      await ApiService.removeCourseFromCart(cartCourseId);
      fetchCartData();
    } catch (error) {
      console.error("Error removing course from cart data:", error);
    }
  };

  useEffect(() => {
    const fetchFullData = async () => {
      try {
        const viewFullData = await ApiService.getNewReleaseCourses(
          itemsPerPage,
        );
        setDataFull(viewFullData);
      } catch (error) {
        console.error("Error fetching full data:", error);
      }
    };

    fetchFullData();
  }, [itemsPerPage]);

  const handleAllChange = (event) => {
    const { checked } = event.target;
    const updatedCheckedItems = {};
    datas.forEach((cart) => {
      cart.cartCourses.forEach((cc) => {
        updatedCheckedItems[cc.course.id] = checked;
      });
    });
    setCheckedItems(updatedCheckedItems);
  };

  const handleItemChange = (event) => {
    const { name, checked } = event.target;
    setCheckedItems((prevState) => ({
      ...prevState,
      [name]: checked,
    }));
  };

  useEffect(() => {
    const newTotal = datas.reduce((acc, cart) => {
      cart.cartCourses.forEach((cc) => {
        if (checkedItems[cc.course.id]) {
          acc += cc.course.price;
        }
      });
      return acc;
    }, 0);
    setTotal(newTotal);
  }, [checkedItems, datas]);

  const paginatedData = datas.slice(
    (pagination - 1) * itemsPerPage,
    pagination * itemsPerPage,
  );

  const paginatedFullData = dataFull.slice(
    (pagination - 1) * itemsPerPage,
    pagination * itemsPerPage,
  );

  // Slide functionality
  const slideLeft = () => {
    if (resultsRef.current) {
      resultsRef.current.scrollLeft -= 1080;
      updateArrowStates();
    }
  };

  const slideRight = () => {
    if (resultsRef.current) {
      resultsRef.current.scrollLeft += 1080;
      updateArrowStates();
    }
  };

  const updateArrowStates = () => {
    const scrollLeft = resultsRef.current.scrollLeft;
    const scrollWidth = resultsRef.current.scrollWidth;
    const clientWidth = resultsRef.current.clientWidth;

    setIsLeftDisabled(scrollLeft === 0);
    setIsRightDisabled(scrollLeft >= scrollWidth - clientWidth);
  };

  useEffect(() => {
    updateArrowStates();
  }, [dataFull, pagination]);

  // Mouse drag functionality
  const handleMouseDown = (e) => {
    const slider = resultsRef.current;
    slider.isDown = true;
    slider.startX = e.pageX - slider.offsetLeft;
    slider.scrollLeftStart = slider.scrollLeft;
  };

  const handleMouseLeave = () => {
    const slider = resultsRef.current;
    slider.isDown = false;
  };

  const handleMouseUp = () => {
    const slider = resultsRef.current;
    slider.isDown = false;
  };

  const handleMouseMove = (e) => {
    const slider = resultsRef.current;
    if (!slider.isDown) return;
    e.preventDefault();
    const x = e.pageX - slider.offsetLeft;
    const walk = (x - slider.startX) * 3.5;
    slider.scrollLeft = slider.scrollLeftStart - walk;
  };

  const handlePayment = async () => {
    const selectedCartCourseIds = datas
      .flatMap((cart) => cart.cartCourses)
      .filter((item) => checkedItems[item.course.id])
      .map((item) => item.cartCourseId);

    if (selectedCartCourseIds.length === 0) {
      alert("No courses selected for payment.");
      return;
    }

    try {
      const response = await ApiService.payCartCourse(
        selectedCartCourseIds,
        user.id,
      );
      if (response.status === 1) {
        alert("Payment successful");
      } else if (response.status === 2) {
        alert(
          "Your wallet balance is insufficient, please choose Credit Card or Paypal.",
        );
      } else {
        alert("Payment failed: " + response.Message);
      }
    } catch (error) {
      console.error("Error during payment:", error);
    }
  };

  const redirectToPaypal = async (total, userId) => {
    if (total > 0) {
      try {
        const response = await ApiService.createPaypalOrder(total, userId);
        const approvalUrl = response.links.find(
          (link) => link.rel === "approve",
        ).href;
        window.location.href = approvalUrl;
      } catch (error) {
        console.error("Error creating PayPal order: ", error);
      }
    }
  };

  useEffect(() => {
    const handleRedirectPayout = async () => {
      const urlParams = new URLSearchParams(window.location.search);
      const orderId = urlParams.get("token");
      const payerId = urlParams.get("PayerID");
      const hasCaptured = localStorage.getItem(`order-captured-${orderId}`);

      if (hasCaptured === "true") {
        console.log("Order has already been captured.");
        return;
      }

      if (orderId && payerId) {
        try {
          console.log(`Token: ${orderId}, PayerId: ${payerId}`);
          await ApiService.capturePaypalOrder(orderId);
          localStorage.setItem(`order-captured-${orderId}`, "true");
        } catch (error) {
          console.error("Error capturing order:", error);
        }
      }
    };

    const handleCancelOrder = async () => {
      const urlParams = new URLSearchParams(window.location.search);
      const orderId = urlParams.get("token");

      if (orderId) {
        try {
          await ApiService.cancelPaypalOrder(orderId);
          localStorage.removeItem(`order-captured-${orderId}`);
        } catch (error) {
          console.error("Error canceling order:", error);
        }
      }
    };

    const urlParams = new URLSearchParams(window.location.search);
    const payerId = urlParams.get("PayerID");

    if (payerId) {
      handleRedirectPayout();
    } else {
      handleCancelOrder();
    }
  }, []);

  useEffect(() => {
    if (isOpenVisible) {
      document.body.style.overflow = "hidden";
    } else {
      document.body.style.overflow = "auto";
    }
  }, [isOpenVisible]);

  useEffect(() => {
    document.body.style.overflow = isOpenVisible ? "hidden" : "auto";
  }, [isOpenVisible]);

  return (
    <div id="Cart">
      <div className="display-cart">
        <div className="text-container">
          <h2>Shopping Cart Checkout</h2>
        </div>

        <div className="container">
          <div className="container1">
            <Box>
              <FormControlLabel
                control={
                  <Checkbox
                    checked={Object.values(checkedItems).every(Boolean)}
                    onChange={handleAllChange}
                  />
                }
                label="All"
              />
            </Box>
            {paginatedData.map((cart, index) =>
              cart.cartCourses.map((item, idx) => (
                <div key={`${index}-${idx}`} className="container1-row">
                  <div className="container1-row1">
                    <hr />
                    <Box
                      display="flex"
                      justifyContent="center"
                      alignItems="center"
                      width="100%"
                      height="80px"
                    >
                      <Checkbox
                        name={item.course.id}
                        checked={checkedItems[item.course.id] || false}
                        onChange={handleItemChange}
                      />
                    </Box>
                  </div>
                  <div className="container1-row2">
                    <hr />
                    <div className="column">
                      <div className="cover-img-course">
                        <img
                          src={item.course.imgUrl}
                          alt="Course"
                          className="avatar"
                        />
                      </div>
                      <div className="course-container">
                        <div className="course-title">
                          <h2>{item.course.name}</h2>
                        </div>
                        <div className="course-of-instructor">
                          <h2>{item.course.user.name}</h2>
                        </div>
                        <Box sx={{ "& > legend": { mt: 2 } }}>
                          <Rating
                            name="read-only"
                            value={item.course.rating}
                            readOnly
                          />
                        </Box>
                      </div>
                      <div className="total-container">
                        <div className="total-container-fix">
                          <h3>$</h3>
                          <h2>{item.course.price.toLocaleString()}</h2>
                        </div>
                        <div className="button-delete-container">
                          <div className="icon-bt">
                            <MdOutlineDeleteForever
                              onClick={() =>
                                removeCourseFromCart(item.cartCourseId)
                              }
                              size={20}
                            />
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              )),
            )}
          </div>
          <div className="container2">
            <div className="container-total">
              <div className="column1">
                <h2>Total:</h2>
              </div>

              <div className="column2">
                <h3>$</h3>
                <h2>{total.toLocaleString()}</h2>
              </div>

              <div className="column3">
                <button
                  className={`pay-bt ${total === 0 ? "disabled" : ""}`}
                  style={{
                    pointerEvents: total > 0 ? "auto" : "none",
                    color: total > 0 ? "white" : "white",
                  }}
                  onClick={() => {
                    total > 0 && setIsOpenVisible(true);
                  }} // Only setIsOpenVisible if total > 0
                >
                  <div className="icon">
                    <MdPayments size={20} />
                  </div>

                  <div className="text">
                    <h2>
                      {total > 0 ? "Continue" : "Select Items to Continue"}
                    </h2>
                  </div>
                </button>

                <div
                  className="popup-paymentnow"
                  style={
                    isOpenVisible ? { display: "block" } : { display: "none" }
                  }
                >
                  <div className="popup-paymentnow-buttonclose-container">
                    <div
                      className="popup-paymentnow-buttonclose"
                      onClick={() => {
                        setIsOpenVisible(false);
                      }}
                      title="Close Popup"
                    >
                      Close X
                    </div>
                  </div>

                  <div className="popup-row">
                    <div className="popup-row-title">
                      <p>Select Payment Method</p>
                    </div>

                    <div className="popup-row-text">
                      <p>
                        "Choose your payment method: Use 'Pay Now' to pay
                        directly from your wallet balance. If your wallet
                        balance is insufficient, please select either 'Credit
                        Card' or 'Paypal' to complete the transaction."
                      </p>
                    </div>

                    {/* <div>
                      <button className="popup-row-button">Save changes</button>
                    </div> */}

                    <div className="display-button">
                      <button
                        className={`pay-bt1 ${total === 0 ? "disabled" : ""}`}
                        style={{
                          pointerEvents: total > 0 ? "auto" : "none",
                          color: total > 0 ? "white" : "white",
                        }}
                        onClick={handlePayment}
                      >
                        <div className="icon">
                          <IoWalletSharp size={20} />
                        </div>

                        <div className="text">
                          <h2>
                            {total > 0 ? "Pay Now" : "Select Items to Continue"}
                          </h2>
                        </div>
                      </button>

                      <Link to={`/student/payout`}>
                        <button
                          className={`pay-bt2 ${total === 0 ? "disabled" : ""}`}
                          style={{
                            pointerEvents: total > 0 ? "auto" : "none",
                            color: total > 0 ? "white" : "white",
                          }}
                        >
                          <div className="icon">
                            <CiCreditCard2 size={30} />
                          </div>

                          <div className="text">
                            <h2>
                              {total > 0
                                ? "Credit Card"
                                : "Select Items to Continue"}
                            </h2>
                          </div>
                        </button>
                      </Link>

                      <button
                        className={`pay-bt3 ${total === 0 ? "disabled" : ""}`}
                        style={{
                          pointerEvents: total > 0 ? "auto" : "none",
                          color: total > 0 ? "black" : "white",
                        }}
                        onClick={() => redirectToPaypal(total, user.id)}
                      >
                        <div className="icon">
                          <RiPaypalFill size={20} />
                        </div>
                        <div className="text">
                          <h2>
                            {total > 0 ? "PayPal" : "Select Items to Continue"}
                          </h2>
                        </div>
                      </button>
                    </div>
                  </div>
                </div>

                <div
                  className="overlay1"
                  style={
                    isOpenVisible ? { display: "block" } : { display: "none" }
                  }
                  onClick={() => {
                    setIsOpenVisible(false);
                  }}
                ></div>
              </div>
            </div>
          </div>
        </div>

        <div className="text2-container">
          <h2>You might also like</h2>
        </div>

        <div className="results-slider">
          <div
            className={`arrowleft ${isLeftDisabled ? "disabled" : ""}`}
            onClick={slideLeft}
          >
            <IoIosArrowRoundBack size={30} />
          </div>
          <div
            className="results"
            ref={resultsRef}
            onMouseDown={handleMouseDown}
            onMouseLeave={handleMouseLeave}
            onMouseUp={handleMouseUp}
            onMouseMove={handleMouseMove}
          >
            {paginatedFullData.map((course, index) => (
              <div className="result" key={`${index}-${course.id}`}>
                <div className="img-container">
                  <Link to={`/courses/${course.name}`}>
                    <img
                      src={course.image[0]?.url}
                      className="background"
                      alt={`Background for ${course.name}`}
                    />
                  </Link>
                  <div className="owner">
                    <span></span>
                  </div>
                  <div className="save-course-btn">
                    <GoBookmark />
                  </div>
                </div>
                <div className="title">
                  <Link
                    to={`/courses/${course.name}`}
                    className="course-title-link"
                  >
                    <div className="title-font">
                      <span>{course.name}</span>
                    </div>
                  </Link>
                </div>
                <div className="info">
                  <div className="difficult tag">
                    <BsBarChartLine />
                    <span>{course.level}</span>
                  </div>
                  <div className="lecture tag">
                    <IoVideocamOutline />
                    <span>Videos</span>
                  </div>
                  <div className="time tag">
                    <AiOutlineFieldTime />
                    <span>{(course.timeLearning / 60).toFixed(1)} Hrs</span>
                  </div>
                </div>
                <div className="rating-countS">
                  <div className="rating card">
                    <TiStarOutline />
                    <span className="card-info">{course.ratingAvg}</span>
                    <span className="card-hint">({course.ratingCount})</span>
                  </div>
                  <div className="student card">
                    <PiUserCircleFill />
                    <span className="card-info">{course.enrolledNumber}</span>
                    <span className="card-hint">Students</span>
                  </div>
                </div>
                <div className="price-add">
                  <span className="price">
                    ${course.price.toLocaleString()}
                  </span>
                  <div className="btn-contain">
                    <Stack spacing={2} direction="row">
                      <Button
                        variant="contained"
                        style={{ borderRadius: "10px", padding: "10px 20px" }}
                        onClick={() => addCourseToCart(course.id, user.id)}
                      >
                        Add To Cart
                      </Button>
                    </Stack>
                  </div>
                </div>
              </div>
            ))}
          </div>
          <div
            className={`arrowright ${isRightDisabled ? "disabled" : ""}`}
            onClick={slideRight}
          >
            <IoIosArrowRoundForward size={30} />
          </div>
        </div>
      </div>
    </div>
  );
}
