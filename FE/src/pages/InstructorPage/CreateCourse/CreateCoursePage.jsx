import React, { useContext, useEffect, useState } from "react";
import "./CreateCoursePage.css";
import SidebarCreateCourse from "../../../components/Courses/CreateCourse/SidebarCreateCourse/SidebarCreateCourse";
import ItemContent from "../../../components/Courses/CreateCourse/ItemContent/ItemContent";
import { AuthContext } from "../../Context/AuthContext";
import { useNavigate } from "react-router-dom";

export default function CreateCoursePage() {
  const [selected, setSelected] = useState("curriculum");
  const [itemSelected, setItemSelected] = useState({
    chapterIndex: 0,
    itemIndex: 0,
  });
  const [data, setData] = useState([]);

  const addChapter = () => {
    const newChapter = {
      index: data.length + 1,
      name: "Untitled chapter",
      items: [],
    };
    setData([...data, newChapter]);
  };

  const addLession = (index) => {
    setData((data) =>
      data.map((chapter, indexChapter) => {
        if (indexChapter === index) {
          return {
            ...chapter,
            items: [
              ...chapter.items,
              {
                index: chapter.items.length + 1,
                name: "Untitled lessson",
                type: "",
              },
            ],
          };
        }
        return chapter;
      }),
    );
  };

  const handleItemClick = (chapterIndex, itemIndex) => {
    setItemSelected({
      chapterIndex: chapterIndex,
      itemIndex: itemIndex,
    });
  };

  const resetWhenSave = () => {
    setItemSelected({
      chapterIndex: 0,
      itemIndex: 0,
    });
  };

  const handleUpdateNameChapter = (value, index) => {
    setData((data) =>
      data.map((chapter, indexChapter) => {
        if (indexChapter === index) {
          return {
            ...chapter,
            name: value,
          };
        }
        return chapter;
      }),
    );
  };

  const hanldeUpdateLessonType = (value, index1, index2) => {
    setData((data) =>
      data.map((chapter, indexChapter) => {
        if (indexChapter === index1) {
          return {
            ...chapter,
            items: chapter.items.map((item, indexItem) => {
              if (indexItem === index2) {
                return {
                  ...item,
                  type: value,
                };
              }
              return item;
            }),
          };
        }
        return chapter;
      }),
    );
  };

  const { user, roles } = useContext(AuthContext);
  const nav = useNavigate();

  useEffect(() => {
    if (!user) {
      nav("/login");
    } else if (!roles.includes("Instructor")) {
      nav("/error");
    }
  }, [user, roles, nav]);

  return (
    <div id="create-course-page">
      <div className="nav-bar">
        <div
          className={`nav ${selected === "curriculum" ? "active" : ""}`}
          onClick={() => {
            setSelected("curriculum");
          }}
        >
          Curriculum
        </div>
        <div
          className={`nav ${selected === "settings" ? "active" : ""}`}
          onClick={() => {
            setSelected("settings");
          }}
        >
          Settings
        </div>
      </div>
      {selected === "curriculum" && (
        <div className="content-curriculum">
          <div className="sidebar-container">
            <SidebarCreateCourse
              data={data}
              addChapter={addChapter}
              addLession={addLession}
              handleItemClick={handleItemClick}
            />
          </div>
          <div className="items-container">
            <ItemContent
              itemSelected={itemSelected}
              data={data}
              resetWhenSave={resetWhenSave}
              handleUpdateNameChapter={handleUpdateNameChapter}
              hanldeUpdateLessonType={hanldeUpdateLessonType}
            />
          </div>
        </div>
      )}
    </div>
  );
}
