import React, { useEffect, useRef, useState } from "react";
import "./SliderCards.css";
import Card from "../Card/Card";
import Skeleton from '@mui/material/Skeleton';
import Stack from '@mui/material/Stack';
import { IoIosArrowRoundForward } from "react-icons/io";
import { IoIosArrowRoundBack } from "react-icons/io";

export default function SliderCards({ datas }) {
  const [datasLength, setDataLength] = useState(0);
  const [isAtStart, setIsAtStart] = useState(true);
  const [isAtEnd, setIsAtEnd] = useState(false);

  useEffect(() => {
    if (datas) {
      setDataLength(datas.length);
      console.log(datas.length)
    }
  }, [datas])
  const sliderRef = useRef(null);
  const slideLeft = () => {
    if (sliderRef.current) {
      sliderRef.current.scrollLeft -= 1080;
      checkScrollPosition();
    }
  };

  const slideRight = () => {
    if (sliderRef.current) {
      sliderRef.current.scrollLeft += 1080;
      checkScrollPosition();
    }
  };

  const checkScrollPosition = () => {
    if (sliderRef.current) {
      const { scrollWidth, scrollLeft, clientWidth } = sliderRef.current;
      setIsAtStart(scrollLeft === 0);
      setIsAtEnd(scrollLeft + clientWidth >= scrollWidth);
    }
  };
  useEffect(() => {
    const slider = sliderRef.current;
    if (slider) {
      slider.addEventListener('scroll', checkScrollPosition);
      checkScrollPosition();
    }
    return () => {
      if (slider) {
        slider.removeEventListener('scroll', checkScrollPosition);
      }
    };
  }, [datasLength]);
  return (
    <div id="slider-cards">
      {datasLength > 6 && (
        <div
          className={`arrow left ${isAtStart ? 'disabled' : ''}`}
          onClick={!isAtStart ? slideLeft : null}
        >
          <IoIosArrowRoundBack />
        </div>
      )}
      <div id="slider-cards-container" ref={sliderRef}>
        {!(datas == null || datas.length == 0) ? datas.map((data, index) => (
          <Card data={data} key={index} />
        )) : (
          <Stack direction="row" spacing={1} sx={{ display: 'flex' }}>
            <Skeleton variant="rounded" width={160} height={280} style={{ padding: '5px', margin: '0 10px' }} />
            <Skeleton variant="rounded" width={160} height={280} style={{ padding: '5px', margin: '0 10px' }} />
            <Skeleton variant="rounded" width={160} height={280} style={{ padding: '5px', margin: '0 10px' }} />
            <Skeleton variant="rounded" width={160} height={280} style={{ padding: '5px', margin: '0 10px' }} />
            <Skeleton variant="rounded" width={160} height={280} style={{ padding: '5px', margin: '0 10px' }} />
            <Skeleton variant="rounded" width={160} height={280} style={{ padding: '5px', margin: '0 10px' }} />
          </Stack>
        )}
      </div>
      {datasLength > 6 && (
        <div
          className={`arrow right ${isAtEnd ? 'disabled' : ''}`}
          onClick={!isAtEnd ? slideRight : null}
        >
          <IoIosArrowRoundForward />
        </div>
      )}
    </div>
  );
}

