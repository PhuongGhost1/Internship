import React, { useState, useEffect, useRef } from "react";
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
import ApiService from "../../../api/ApiService";
import { Link } from "react-router-dom";
import { IoIosArrowRoundBack, IoIosArrowRoundForward } from "react-icons/io";

export default function Cart() {
  const [datas, setDatas] = useState([]);
  const [dataFull, setDataFull] = useState([]);
  const [checkedItems, setCheckedItems] = useState({});
  const [total, setTotal] = useState(0);
  const itemsPerPage = 100;
  const [pagination, setPagination] = useState(1);
  const resultsRef = useRef(null);
  const [isLeftDisabled, setIsLeftDisabled] = useState(true);
  const [isRightDisabled, setIsRightDisabled] = useState(false);

  const fetchCartData = async () => {
    try {
      const viewcartData = await ApiService.getCart("user_2a120a4776");
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
      await ApiService.addCourseToCart(CourseId, UserId);
      fetchCartData();
    } catch (error) {
      console.error("Error adding course to cart data:", error);
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
          itemsPerPage
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
    pagination * itemsPerPage
  );

  const paginatedFullData = dataFull.slice(
    (pagination - 1) * itemsPerPage,
    pagination * itemsPerPage
  );

  const selectedCourseName =
    datas
      .flatMap((cart) => cart.cartCourses)
      .map((item) => item.course.name)[0] || "";

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
              ))
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
                <div className="pay-bt">
                  <div className="icon">
                    <MdPayments size={20} />
                  </div>

                  <div className="text">
                    <h2>
                      <Link
                        to="/student/payout"
                        state={{
                          total: Number(total),
                          courseName: selectedCourseName,
                        }}
                      >
                        Pay
                      </Link>
                    </h2>
                  </div>
                </div>
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
                  <img
                    src={course.image[0]?.url}
                    className="background"
                    alt="Course background"
                  />
                  <div className="owner">
                    <span></span>
                  </div>
                  <div className="save-course-btn">
                    <GoBookmark />
                  </div>
                </div>
                <div className="title">
                  <div className="title-font">
                    <span>{course.name}</span>
                  </div>
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
                    <span className="card-info">128</span>
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
                        onClick={() =>
                          addCourseToCart(course.id, "user_2a120a4776")
                        }
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
