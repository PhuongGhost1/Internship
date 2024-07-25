import React from "react";
import "./InfoFollow.css";
import Avarta from '../../../../../assets/user-photo.png'


const follow = [
     { avatar: Avarta, name: 'Nguyễn Minh Quân', role: 'User' },
     { avatar: Avarta, name: 'Nguyễn Minh Quân', role: 'User' },
     { avatar: Avarta, name: 'Nguyễn Minh Quân', role: 'User' },
     { avatar: Avarta, name: 'Nguyễn Minh Quân', role: 'User' },
     { avatar: Avarta, name: 'Nguyễn Minh Quân', role: 'User' },
     { avatar: Avarta, name: 'Nguyễn Minh Quân', role: 'User' },
     { avatar: Avarta, name: 'Nguyễn Minh Quân', role: 'User' },

];
export default function InfoFollow() {
     return (
          <div id="InfoFollow">
               <div className="followinfo-container">
                    <h3>Follow</h3>
                    {follow.map((follow, index) => (
                         <div key={index} className="follow">
                              <img src={follow.avatar} alt={`${follow.name}'s avatar`} className="avatar" />
                              <div className="info">
                                   <span className="name">{follow.name}</span>
                                   <span className="role">{follow.role}</span>
                              </div>
                         </div>
                    ))}
               </div>
          </div>
     )
}