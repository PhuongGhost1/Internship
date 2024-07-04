import axios from 'axios'

const ApiService = {
    getCourseByName: async (courseName) => {
        try {
            const respose = await axios.post('http://localhost:5144/api/v1/web/course/find-course', {
                courseName: 'prompt-engineering-specialization'
            }, {
                headers: {
                    'Content-Type': 'application/json',
                },
            })
            return respose.data
        } catch (error) {

        }
    }
}

export default ApiService;