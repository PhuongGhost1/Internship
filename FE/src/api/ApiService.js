import axios from 'axios'
import LoginPage from '../pages/AuthPage/LoginPage/LoginPage';

const ApiService = {
    getCourseByName: async (courseName) => {
        try {
            const response = await axios.post('http://localhost:5144/api/v1/web/course/find-course', { courseName: courseName }, {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded',
                },
            });
            return response.data
        } catch (error) {

        }
    },
    LoginPage: async()
}

export default ApiService;